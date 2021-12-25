namespace FR.Tools.Selecting
{
    public class SingleSelection : Selection
    {
        public override bool CanAdd(Selectable selectable)
        {
            return IsEmpty();
        }
    }
}