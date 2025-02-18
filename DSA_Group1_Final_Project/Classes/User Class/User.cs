using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Group1_Final_Project.Classes.User_Class
{
    public class User
    {
        
        public string id {  get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string reenterPassword { get; set; }
        public int tempId {  get; set; }
        public int courseKey {  get; set; }

        private bool disposed = false;

        public User(string Id, string Username, string Password, string Reenterpassword, int TempId, int CourseKey)
        {
            this.username = Username;
            this.password = Password;
            this.reenterPassword = Reenterpassword;

            if (string.IsNullOrEmpty(Id))
            {
                this.id = string.Empty;
                this.tempId = 0;
                this.courseKey = 0;
            }
            else
            {
                this.id = Id;
                this.tempId = TempId;
                this.courseKey = CourseKey;
            }
        }

        bool checkPassword(string Password)
        {
            if (Password == this.password && Password == this.reenterPassword) { return true; }
            return false;
        }

        char checkAuthority() 
        {
            return this.id[0];            
        }

        //memory management
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    

                }
                disposed = true;
            }
        }

        ~User()
        {
            Dispose(false);
        }

    }
}
