namespace IdentityItI.Models
{
    public class Feed
    {

        public int   Id { get; set; }


        public String feedback { get; set; }
    
          public String response { get; set; }
        public String userId { get; set; }
        public ApplicationUser user { get; set; }


    }
}
