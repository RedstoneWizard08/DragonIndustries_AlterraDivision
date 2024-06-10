namespace ReikaKalseki.DIAlterra.Api.Auxiliary;

public interface ItemDef<E> : ItemDef
{
    E getItem();

    ItemDef<E> addIngredient(TechType item, int amt);

    ItemDef<E> addIngredient(ItemDef item, int amt);
}

public interface ItemDef
{
    TechType getTechType();
}