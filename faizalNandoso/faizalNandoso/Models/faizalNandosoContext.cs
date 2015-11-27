using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace faizalNandoso.Models
{
    //this tells that we are using the MySql database
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class faizalNandosoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        public class MyConfiguration : DbMigrationsConfiguration<faizalNandosoContext>
        {
            public MyConfiguration()
            {
                //enable migrations so db knows how to update based on model
                this.AutomaticMigrationsEnabled = true;
                this.AutomaticMigrationDataLossAllowed = true;
            }

            protected override void Seed(faizalNandosoContext context)
            {
                List<comments> comments_to_add = new List<comments>()
                {
                    new comments {UserName = "Sam", Comment = "Great job guys keep it up" },
                    new comments {UserName = "Harry", Comment = "Stale food, too cold, service is not good" },
                    new comments {UserName = "Matt", Comment = "Do you guys sell kids meals" },
                    new comments {UserName = "Jessica", Comment = "What are your opening hours for christmas holidays" },
                };

                comments_to_add.ForEach(s => context.comments.Add(s));
                context.SaveChanges();

            }
        }







    













    public faizalNandosoContext() : base("name=faizalNandosoContext")
        {
        Database.SetInitializer(new MigrateDatabaseToLatestVersion<faizalNandosoContext, MyConfiguration>());
    }

    public System.Data.Entity.DbSet<faizalNandoso.Models.comments> comments { get; set; }
}
}
