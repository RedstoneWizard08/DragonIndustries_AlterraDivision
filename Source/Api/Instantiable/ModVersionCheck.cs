﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using ReikaKalseki.DIAlterra.Api.Util;
using ReikaKalseki.DIAlterra.Config;

namespace ReikaKalseki.DIAlterra.Api.Instantiable;

public class ModVersionCheck : IComparable<ModVersionCheck>
{
    private static readonly string VERSION_FILE = "current-version.txt";

    private static readonly List<ModVersionCheck> modVersions = new();
    public readonly ModVersion currentVersion;

    public readonly string modName;

    public readonly Func<ModVersion> remoteVersion;

    private ModVersion fetchedRemoteVersion;

    public ModVersionCheck(string n, ModVersion cur, Func<ModVersion> rem)
    {
        modName = n;
        remoteVersion = rem;
        currentVersion = cur;
    }

    public int CompareTo(ModVersionCheck other)
    {
        return string.Compare(modName, other.modName, StringComparison.InvariantCultureIgnoreCase);
    }

    public void register()
    {
        modVersions.Add(this);
        modVersions.Sort();
        SNUtil.log("Registered version check " + this, SNUtil.tryGetModDLL(true));
    }

    public override string ToString()
    {
        return string.Format("[ModVersionCheck ModName={0}, RemoteVersion={1}, CurrentVersion={2}]", modName,
            fetchedRemoteVersion, currentVersion);
    }

    private void performRemoteCheck()
    {
        fetchedRemoteVersion = remoteVersion.Invoke();
    }

    public bool isOutdated()
    {
        if (fetchedRemoteVersion == null) //if not yet fetched for some reason block the thread until it is
            fetchedRemoteVersion = remoteVersion.Invoke();
        return !hasVersionError() && fetchedRemoteVersion.CompareTo(currentVersion) > 0;
    }

    public bool hasVersionError()
    {
        return fetchedRemoteVersion == ModVersion.ERROR || currentVersion == ModVersion.ERROR;
    }

    public static ModVersionCheck getFromGitVsInstall(string modName, Assembly a, string repo)
    {
        return new ModVersionCheck(modName, getFromInstall(a), () => getModifiedTimeFromGitFile(repo));
    }

    private static ModVersion getFromInstall(Assembly a)
    {
        try
        {
            var local = Path.Combine(Path.GetDirectoryName(a.Location), VERSION_FILE);
            var text = File.ReadAllLines(local)[0];
            return ModVersion.parse(text);
        }
        catch (Exception ex)
        {
            SNUtil.log("Failed to get local git version: " + ex);
            return ModVersion.ERROR;
        }
    }

    private static ModVersion getModifiedTimeFromGitFile(string repo)
    {
        try
        {
            var prev = DateTime.Now;
            SNUtil.log("Fetching remote version from " + repo, SNUtil.diDLL);
            var url = "https://raw.githubusercontent.com/ReikaKalseki/" + repo + "/main/" + VERSION_FILE;
            var text = new WebClient().DownloadString(url);
            var mv = ModVersion.parse(text);
            var after = DateTime.Now;
            SNUtil.log(
                "Version check for " + repo + " done in " + (after - prev).TotalSeconds.ToString("0.000") +
                " seconds; version = " + mv, SNUtil.diDLL);
            return mv;
        }
        catch (Exception ex)
        {
            var str = ex.ToString();
            SNUtil.log("Failed to get remote " + repo + " git version: " + str, SNUtil.diDLL);
            if (str.StartsWith("System.Net.WebException", StringComparison.InvariantCultureIgnoreCase) &&
                str.Contains("ConnectFailure"))
            {
                SNUtil.log("Could not connect to server!", SNUtil.diDLL);
                SNUtil.createPopupWarning(
                    "Could not connect to " + repo +
                    " GitHub for versions. Check your internet/firewall/proxy settings.", false);
            }

            return ModVersion.ERROR;
        }
    }

    public static List<ModVersionCheck> getOutdatedVersions()
    {
        return modVersions.FindAll(mv => mv.isOutdated());
    }

    public static List<ModVersionCheck> getErroredVersions()
    {
        return modVersions.FindAll(mv => mv.hasVersionError());
    }

    public static void fetchRemoteVersions()
    {
        if (DIMod.config.getBoolean(DIConfig.ConfigEntries.THREADVER))
        {
            var t = new Thread(doFetchRemoteVersions);
            t.Name = "Remote mod version checks";
            t.Start();
        }
        else
        {
            doFetchRemoteVersions();
        }
    }

    private static void doFetchRemoteVersions()
    {
        SNUtil.log("Fetching remote mod versions", SNUtil.diDLL);
        foreach (var mv in modVersions) mv.performRemoteCheck();
    }
}

public class ModVersion : IComparable<ModVersion>
{
    public static readonly string dateFormat = "dd/MM/yyyy HH:mm";

    internal static readonly ModVersion ERROR = new(-1, DateTime.MinValue);
    public readonly DateTime date;

    public readonly int version;

    public ModVersion(int ver, DateTime d)
    {
        version = ver;
        date = d;
    }

    public int CompareTo(ModVersion other)
    {
        return version.CompareTo(other.version);
    }

    public override string ToString()
    {
        return this == ERROR ? "INVALID" : "v" + version + " @ " + date.ToString(dateFormat);
    }

    public override int GetHashCode()
    {
        return version;
    }

    public override bool Equals(object o)
    {
        return o is ModVersion && ((ModVersion) o).version == version;
    }

    public static ModVersion parse(string input)
    {
        if (string.IsNullOrEmpty(input))
            throw new Exception("No version information present!");
        input = input.Trim();
        if (input[0] == 'v' || input[0] == 'V')
            input = input.Substring(1);
        var idx = input.IndexOf('@');
        var at = idx > 0;
        idx = input.IndexOf(' ', Math.Max(idx, 0));
        var idx2 = at ? input.IndexOf(' ') : idx;
        return new ModVersion(int.Parse(input.Substring(0, idx2)),
            DateTime.ParseExact(input.Substring(idx + 1), dateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None));
    }
}