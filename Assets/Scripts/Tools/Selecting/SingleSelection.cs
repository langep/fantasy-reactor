namespace FR.Tools.Selecting
{
    public class SingleSelection : Selection
    {
        public SingleSelection() : base()
        {
        }

        public override bool HasRoomFor(uint count = 1)
        {
            return Count == 0;
        }
    }
}