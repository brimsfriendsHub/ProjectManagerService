
using NUnit.Framework;
using ProjecManagement.BusinessLayer.Implementation;
using ProjecManagement.BusinessLayer.ViewModel;
using ProjecManagement.EntityLayer;
using ProjecManagement.Repositories;
using System.Linq;
namespace ProjectManagementNunitTesting
{
    [TestFixture]
    public class UserDetailsTest
    {

        public UserDetailsViewModel GetInPut()
        {
            UserDetailsViewModel Input = new UserDetailsViewModel();
            Input.FirstName = "TestUserFirstName";
            Input.LastName = "TestUserLastName";
            Input.EmployeeId = 54321;
            return Input;
        }
        [Test, Order(1)]
        public void CreateUser()
        {


            IRepository<UserDetails> userRepository = new Repository<UserDetails>();
            UserDetailsBL df = new UserDetailsBL(userRepository);
            var Input = GetInPut();
            if (Input != null)
                df.SaveUserDetailsRecord(Input);
            var UserDetailList = df.GetAllUserDetailsRecord();
            var qq = UserDetailList.Where(tt => tt.EmployeeId == Input.EmployeeId);
            if (qq != null)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }
        [Test, Order(2)]
        public void UserDetailsById()
        {
            var Input = GetInPut();
            IRepository<UserDetails> userRepository = new Repository<UserDetails>();
            UserDetailsBL df = new UserDetailsBL(userRepository);

            var UserDetailList = df.GetAllUserDetailsRecord();
            var qq = UserDetailList.Where(tt => tt.EmployeeId == Input.EmployeeId).FirstOrDefault();
            if (qq != null)
            {
                if (qq.EmployeeId == Input.EmployeeId)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }

        }

        [Test, Order(3)]
        public void GetAllUserDetails()
        {
            //int intUserId = 2;
            IRepository<UserDetails> userRepository = new Repository<UserDetails>();
            UserDetailsBL df = new UserDetailsBL(userRepository);
            var UserDetailList = df.GetAllUserDetailsRecord();
            if (UserDetailList != null && UserDetailList.Count() > 0)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }

        }

        [Test, Order(4)]
        public void DeleteUserDetail()
        {
            //int intUserId = 2;

            var Input = GetInPut();
            IRepository<UserDetails> userRepository = new Repository<UserDetails>();
            UserDetailsBL UDBL = new UserDetailsBL(userRepository);
            var UserDetailList = UDBL.GetAllUserDetailsRecord();
            var qq = UserDetailList.Where(tt => tt.EmployeeId == Input.EmployeeId).FirstOrDefault();
            UDBL.DeleteUserDetailsRecordByUserId(qq.UserId);
            var UserDetailList1 = UDBL.GetAllUserDetailsRecord();
            var Ul = UserDetailList1.Where(tt => tt.EmployeeId == Input.EmployeeId).FirstOrDefault();
            if (Ul == null)
            {
                if (qq != Ul)
                {
                    Assert.Pass();
                }
                else
                {
                    Assert.Fail();
                }
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}

