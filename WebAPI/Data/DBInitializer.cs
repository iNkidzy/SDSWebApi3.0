using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.data;
using WebAPI.Helpers;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class DBInitializer:IDBInitializer
    {

        private IAuthenticationHelper authenticationHelper;

      
        public DBInitializer(IAuthenticationHelper authHelper)
        {
            authenticationHelper = authHelper;
        }

        public void Initialize(sdsDBcontext context)
        {
            context.Database.EnsureCreated();

            if(context.TodoItems.Any())
            {
                return;
            }

            List<TodoItem> items = new List<TodoItem>
            {
                new TodoItem { IsComplete=true, Name="I did it!!"},
                new TodoItem { IsComplete=false, Name="Failed...again"},
                new TodoItem { IsComplete=false, Name="<h3>Message from a Black Hat! Ha, ha, ha...<h3>"}
            };

            string password = "nadia";
            byte[] passwordHashChili, passwordSaltChili, passwordHashNadia, passwordSaltNadia;

            authenticationHelper.CreatePasswordHash(password, out passwordHashChili, out passwordSaltChili);
            authenticationHelper.CreatePasswordHash(password, out passwordHashNadia, out passwordSaltNadia);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserChili",
                    PasswordHash = passwordHashChili,
                    PasswordSalt = passwordSaltChili,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminNadia",
                    PasswordHash = passwordHashNadia,
                    PasswordSalt = passwordSaltNadia,
                    IsAdmin = true
                }
            };

            context.TodoItems.AddRange(items);
            context.Users.AddRange(users);
            context.SaveChanges();

        }
    }
}
