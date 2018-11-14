namespace ProjectCompany.Person
{
    public class Skill
    {
        public int Id {get; private set;}
        public string Title { get; private set; }

        public Skill(string title) 
        {
            this.Title = title;
        }
    }
}
