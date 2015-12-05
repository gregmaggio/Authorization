using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

using DTO;
using Action = DTO.Action;

using log4net;

using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class AuthorizationDAOTester : BaseTester
    {
        private static ILog _log = LogManager.GetLogger(typeof(AuthorizationDAOTester));
        private AuthorizationEntities _dao = null;

        [SetUp]
        public void Setup()
        {
            _dao = new AuthorizationEntities();
        }

        [TearDown]
        public void Teardown()
        {
            try
            {
                if (_dao != null)
                {
                    _dao.Dispose();
                }
            }
            catch (Exception ex)
            {
                _log.Warn("Exception", ex);
            }
            _dao = null;
        }

        [Test]
        public void Test1()
        {
            User testUser = null;
            Action testAction = null;
            Role testRole = null;
            try
            {
                int countBefore = _dao.Users.Count();
                _log.DebugFormat("countBefore: {0}", countBefore);

                Action action = new Action()
                {
                    Name = "TestAction"
                };
                _dao.Actions.Add(action);
                _dao.SaveChanges();

                Action[] selectedActions = (from item in _dao.Actions
                                            where string.Compare(item.Name, action.Name, true) == 0
                                            select item).ToArray();
                Assert.Greater(selectedActions.Length, 0);
                testAction = selectedActions[0];

                Role role = new Role()
                {
                    Name = "TestRole"
                };
                role.Actions.Add(testAction);
                _dao.Roles.Add(role);
                _dao.SaveChanges();

                Role[] selectedRoles = (from item in _dao.Roles
                                        where string.Compare(item.Name, role.Name, true) == 0
                                        select item).ToArray();
                Assert.Greater(selectedRoles.Length, 0);
                testRole = selectedRoles[0];

                User user = new User()
                {
                    Email = "tester@test.com",
                    Password = "Test",
                    FirstName = "Tester",
                    LastName = "Tester"
                };
                user.Roles.Add(testRole);
                _dao.Users.Add(user);
                _dao.SaveChanges();

                User[] selectedUsers = (from item in _dao.Users
                                        where string.Compare(item.Email, user.Email, true) == 0
                                        select item).ToArray();

                Assert.Greater(selectedUsers.Length, 0);
                testUser = selectedUsers[0];

                var actions = _dao.LoadActions(testUser.Id);
                Assert.AreEqual(1, actions.Count());

                var roles = _dao.LoadRoles(testUser.Id);
                Assert.AreEqual(1, roles.Count());

                int countAfter = _dao.Users.Count();
                _log.DebugFormat("countAfter: {0}", countAfter);
            }
            finally
            {
                if (testUser != null)
                {
                    _dao.Users.Remove(testUser);
                    _dao.SaveChanges();
                }
                if (testRole != null)
                {
                    _dao.Roles.Remove(testRole);
                    _dao.SaveChanges();
                }
                if (testAction != null)
                {
                    _dao.Actions.Remove(testAction);
                    _dao.SaveChanges();
                }
            }
        }
    }
}
