namespace FR.Tools.DataStructures
{
    public class LimitedSizeOrderedSet<T>: OrderedSet<T>
    {
        public virtual bool HasRoomFor(uint count = 1)
        {
            return true;
        }

        public override bool Add(T item)
        {
            return HasRoomFor(1) && base.Add(item);
        }
    }
}