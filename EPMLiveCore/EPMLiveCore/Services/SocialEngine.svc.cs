using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using EPMLiveCore.SocialEngine.Core;
using EPMLiveCore.SocialEngine.Entities;

namespace EPMLiveCore.Services
{
    [ServiceContract(Namespace = "http://api.epmlive.com/SocialEngine", Name = "SocialEngine")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class SocialEngine
    {
        #region Methods (1) 

        // Public Methods (1) 

        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/activities")]
        [OperationContract]
        public Dictionary<DateTime, List<Thread>> GetActivities()
        {

            return new Dictionary<DateTime, List<Thread>>
            {
                {
                    DateTime.Now.Date-1.Days(), new List<Thread>
                    {
                        new Thread
                        {
                            Id = Guid.NewGuid(),
                            Deleted = false,
                            ItemId = 1,
                            Kind = ObjectKind.ListItem,
                            LastActivityDateTime = DateTime.Now-1.Days(),
                            ListId = Guid.NewGuid(),
                            Title = "Thread 1",
                            Url = "https://www.google.com/",
                            WebId = Guid.NewGuid(),
                            Activities = new List<Activity>
                            {
                                new Activity
                                {
                                    Id = Guid.NewGuid(),
                                    Date = DateTime.Now,
                                    IsMassOperation = false,
                                    Kind = ActivityKind.Created,
                                    UserId = 6
                                }
                            }
                        }
                    }
                },{
                    DateTime.Now.Date, new List<Thread>
                    {
                        new Thread
                        {
                            Id = Guid.NewGuid(),
                            Deleted = false,
                            ItemId = 1,
                            Kind = ObjectKind.ListItem,
                            LastActivityDateTime = DateTime.Now,
                            ListId = Guid.NewGuid(),
                            Title = "Thread 2",
                            Url = "https://www.google.com/",
                            WebId = Guid.NewGuid(),
                            Activities = new List<Activity>
                            {
                                new Activity
                                {
                                    Id = Guid.NewGuid(),
                                    Date = DateTime.Now,
                                    IsMassOperation = false,
                                    Kind = ActivityKind.Created,
                                    UserId = 6
                                }
                            }
                        }
                    }
                }
            };
        }

        #endregion Methods 
    }
}