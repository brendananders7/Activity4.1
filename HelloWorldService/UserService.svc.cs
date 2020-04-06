using Activity3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace HelloWorldService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        List<UserModel> users = new List<UserModel>();

        public UserService()
        {
            users.Add(new UserModel("Bob", "test1"));
            users.Add(new UserModel("Regina", "test2"));
            users.Add(new UserModel("Joe Maw Muh", "test3"));
        }

        //3
        public HelloObject GetModelObject(string id)
        {
            HelloObject helloObject = new HelloObject();

            if (Int32.Parse(id) > 0)
            {
                helloObject.happyHello = true;
                helloObject.helloMessage = "Great day. Couldn't be better eh?";
            }
            else
            {
                helloObject.happyHello = false;
                helloObject.helloMessage = "Feeling very glum. I hope the sun will come out tomorrow :-(";
            }

            return helloObject;
        }

        //2
        public string GetData(string value)
        {
            return "If your voice travels " + value + " feet, then the influence of your voice will cover " + Int32.Parse(value) * Int32.Parse(value) * 3.14 + " sq feet";
        }

        //1
        public string SayHello()
        {
            return "Dear Friend, I pray that all may go well with you and that you may be in good health, as it goes well with your soul.";
        }

        //4
        public DTO GetAllUsers()
        {
            DTO dto = new DTO(0, "OK", users);
            return dto;
                
        }

        //5
        public DTO GetUser(string id)
        {
            int index = Int32.Parse(id);
            if (index > users.Count)
            {
                DTO dto = new DTO(-1, "User Does Not Exist", null);
                return dto;
            }
            else
            {
                List<UserModel> user = new List<UserModel>();
                users.Add(users[index]);
                DTO dto = new DTO(0, "OK", user);
                return dto;
            }
        }
    }
}
