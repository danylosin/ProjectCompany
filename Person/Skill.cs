namespace ProjectCompany.Person
{
    public class Skill
    {
       protected string title;

       public Skill(string title) 
       {
           this.title = title;
       }

       public string GetTitle()
       {
           return this.title;
       }
    }
}
