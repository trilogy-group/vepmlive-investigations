using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Fakes;
using System.Web.UI;
using System.Web.UI.Fakes;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Fakes;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Fakes;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.Utilities.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace EPMLiveCore.Tests.Layouts.epmlive
{
    [TestClass, ExcludeFromCodeCoverage]
    public class SitePermissionsTests
    {
        private IDisposable _shimContext;
        private sitepermissions _testEntity;
        private PrivateObject _privateObject;

        private const string PageLoadMethodName = "Page_Load";
        private const string FillDataMethodName = "fillData";
        private const string GridView1RowDataBoundMethodName = "GridView1_RowDataBound";
        private const string GridView1RowCommandMethodName = "GridView1_RowCommand";
        private const string Button2ClickMethodName = "Button2_Click";
        private const string Button3ClickMethodName = "Button3_Click";

        private const string LabelDescFieldName = "lblDesc";
        private const string GridView1FieldName = "GridView1";
        private const string LabelTitleFieldName = "lblTitle";
        private const string PanelEditFieldName = "pnlEdit";
        private const string PanelFieldName = "pnl";
        private const string HiddenUserIdFieldName = "hdnUserId";
        private const string HiddenUsernameFieldName = "HiddenUsername";
        private const string PanelGroupdsFieldName = "pnlGroups";
        private const string LabelNameFieldName = "lblName";
        private const string LabelUserNameFieldName = "lblUsername";
        private const string LabelEmailFieldName = "lblEmail";
        private Label _labelDesc;
        private Label _labelTitle;
        private Label _labelName;
        private Label _labelUserName;
        private Label _labelEmail;
        private Panel _panel;
        private Panel _panelEdit;
        private Panel _panelGroups;
        private GridView _gridView1;

        private const string DummyString = "DummyString";
        private const string DummyUrl = "DummyUrl";
        private const string DummyGroupName = "DummyGroupName";
        private const string DummyGroupName2 = "DummyGroupName2";
        private const int DummyUserId = 100;
        private const string DummyUserName = "DummyUserName";
        private const string DummyUserNameName = "DummyUserNameName";
        private const string DummyUserEmail = "DummyUserEmail";
        private const string DummyUserLoginName = "DummyUserLoginName";
        private const int DummyUserId2 = 110;
        private const string DummyUserName2 = "DummyUserName2";
        private const string DummyUserEmail2 = "DummyUserEmail2";
        private const string DummyUserLoginName2 = "DummyUserLoginName2";

        [TestInitialize]
        public void TestInitialize()
        {
            _shimContext = ShimsContext.Create();
            _testEntity = new sitepermissions();
            _privateObject = new PrivateObject(_testEntity);

            var gridView = new GridView();
            gridView.Columns.Add(new TemplateField()
            {
            });
            gridView.Columns.Add(new BoundField()
            {
                DataField = "name"
            });
            gridView.Columns.Add(new BoundField()
            {
                DataField = "email"
            });
            gridView.Columns.Add(new BoundField()
            {
                DataField = "group"
            });
            gridView.Columns.Add(new TemplateField()
            {
            });
            _privateObject.SetField(GridView1FieldName, gridView);
            _privateObject.SetField(LabelDescFieldName, new Label());
            _privateObject.SetField(LabelTitleFieldName, new Label());
            _privateObject.SetField(LabelNameFieldName, new Label());
            _privateObject.SetField(LabelUserNameFieldName, new Label());
            _privateObject.SetField(LabelEmailFieldName, new Label());
            _privateObject.SetField(PanelEditFieldName, new Panel());
            _privateObject.SetField(PanelFieldName, new Panel());
            _privateObject.SetField(PanelGroupdsFieldName, new Panel());
            _privateObject.SetField(PanelGroupdsFieldName, new Panel());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _shimContext?.Dispose();
            _testEntity?.Dispose();
        }

        [TestMethod]
        public void PageLoad_CanEditTrue_FillProperties()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrl,
                    SiteGet = () => new ShimSPSite(),
                    GroupsGet = () => new ShimSPGroupCollection().Bind(
                        new SPGroup[]
                        {
                            new ShimSPGroup()
                            {
                                NameGet = () => DummyGroupName,
                                CanCurrentUserEditMembershipGet = () => true,
                                CanCurrentUserViewMembershipGet = () =>  true,
                                UsersGet = () => new ShimSPUserCollection().Bind(
                                    new SPUser[]
                                    {
                                        new ShimSPUser()
                                        {
                                            IsSiteAdminGet = () => true,
                                            IDGet = () => DummyUserId2,
                                            NameGet = () => DummyUserName2,
                                            EmailGet = () => DummyUserEmail2,
                                            LoginNameGet = () => DummyUserLoginName2
                                        },
                                         new ShimSPUser()
                                        {
                                            IsSiteAdminGet = () => true,
                                            IDGet = () => DummyUserId,
                                            NameGet = () => DummyUserName,
                                            EmailGet = () => DummyUserEmail,
                                            LoginNameGet = () => DummyUserLoginName
                                        }
                                    })
                            }
                        }),
                    AllUsersGet = () => new ShimSPUserCollection().Bind(
                        new SPUser[]
                        {
                            new ShimSPUser()
                            {
                                IsSiteAdminGet = () => true,
                                IDGet = () => DummyUserId,
                                NameGet = () => DummyUserName,
                                EmailGet = () => DummyUserEmail,
                                LoginNameGet = () => DummyUserLoginName
                            }
                        })
                }
            };

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _labelTitle.Text.ShouldBe("Manage Site Permissions"),
                () => _labelDesc.Text.ShouldBe("The Site Members list below displays users that have access to this Workspace.  You can edit their permissions or remove them from this site by using the links below."),
                () => _gridView1.Columns[4].Visible.ShouldBeTrue(),
                () => _gridView1.Rows.Count.ShouldBe(2),
                () => _gridView1.Rows[0].Cells[1].Text.ShouldBe(DummyUserName),
                () => _gridView1.Rows[0].Cells[2].Text.ShouldBe(DummyUserEmail),
                () => _gridView1.Rows[0].Cells[3].Text.ShouldBe($"Site Collection Administrator&lt;br&gt;{DummyGroupName}"),
                () => _gridView1.Rows[0].Cells[8].Text.ShouldBe(DummyUserLoginName),
                () => _gridView1.Rows[0].Cells[9].Text.ShouldBe(DummyUserLoginName),
                () => _gridView1.Rows[1].Cells[1].Text.ShouldBe(DummyUserName2),
                () => _gridView1.Rows[1].Cells[2].Text.ShouldBe(DummyUserEmail2),
                () => _gridView1.Rows[1].Cells[3].Text.ShouldBe(DummyGroupName),
                () => _gridView1.Rows[1].Cells[8].Text.ShouldBe(DummyUserLoginName2),
                () => _gridView1.Rows[1].Cells[9].Text.ShouldBe(DummyUserLoginName2));
        }

        [TestMethod]
        public void PageLoad_CanEditFalse_FillProperties()
        {
            // Arrange
            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrl,
                    SiteGet = () => new ShimSPSite(),
                    GroupsGet = () => new ShimSPGroupCollection().Bind(
                    new SPGroup[]
                    {
                        new ShimSPGroup()
                        {
                            NameGet = () => DummyGroupName,
                            CanCurrentUserEditMembershipGet = () => false
                        }
                    })
                }
            };

            ShimPage.AllInstances.IsPostBackGet = sender => true;

            // Act
            _privateObject.Invoke(PageLoadMethodName, this, EventArgs.Empty);

            // Assert
            LoadFields();

            _gridView1.Columns[4].Visible.ShouldBeFalse();
        }

        [TestMethod]
        public void FillData_CantEditFalse_Redirect()
        {
            // Arrange
            var actualUrl = string.Empty;
            var actualRedirectFlag = SPRedirectFlags.Default;
            var actualRedirect = false;

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    GroupsGet = () => new ShimSPGroupCollection().Bind(new SPGroup[0])
                }
            };

            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                actualUrl = url;
                actualRedirectFlag = flags;
                actualRedirect = true;
                return true;
            };

            // Act
            _privateObject.Invoke(FillDataMethodName, new ShimSPSite().Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualUrl.ShouldBe("accessdenied.aspx"),
                () => actualRedirectFlag.ShouldBe(SPRedirectFlags.RelativeToLayoutsPage),
                () => actualRedirect.ShouldBeTrue());
        }

        [TestMethod]
        public void GridView1RowDataBound_Should_AddAtrributeInTheRow()
        {
            // Arrange
            var actualVisible = false;
            var actualAttributeKey = string.Empty;
            var actualAttibuteValue = string.Empty;

            ShimSPContext.CurrentGet = () => new ShimSPContext();

            var linkButton = new ShimLinkButton()
            {
                CommandArgumentGet = () => DummyUserId.ToString()
            };

            var webControlLinkButton = new ShimWebControl(linkButton)
            {
                AttributesGet = () => new ShimAttributeCollection()
                {
                    AddStringString = (keyParam, valueParam) =>
                    {
                        actualAttributeKey = keyParam;
                        actualAttibuteValue = valueParam;
                    }
                }
            };
            var controlLinkButton = new ShimControl(linkButton)
            {
                VisibleSetBoolean = visible => actualVisible = visible
            };

            var gridViewRow = new ShimGridViewRow()
            {
                RowTypeGet = () => DataControlRowType.DataRow,

            };
            var controlGridViewRow = new ShimControl(gridViewRow)
            {
                FindControlString = controlName => linkButton
            };

            var eventArgSend = new ShimGridViewRowEventArgs()
            {
                RowGet = () => gridViewRow
            };

            _privateObject.SetField(HiddenUserIdFieldName, new HiddenField()
            {
                Value = DummyUserId.ToString()
            });

            // Act
            _privateObject.Invoke(GridView1RowDataBoundMethodName, this, eventArgSend.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualVisible.ShouldBeFalse(),
                () => actualAttributeKey.ShouldBe("onclick"),
                () => actualAttibuteValue.ShouldBe("javascript:return confirm('Are you sure you want to delete  from your site?')"));
        }

        [TestMethod]
        public void GridViewRowCommand_CommandDel_RemoveUserRedirect()
        {
            // Arrange
            var actualUrl = string.Empty;
            var actualRedirectFlag = SPRedirectFlags.Default;
            var actualRedirect = false;
            var actualUserRemoved = false;

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    AllUsersGet = () => new ShimSPUserCollection()
                    {
                        ItemGetString = itemName => new ShimSPUser()
                    },
                    GroupsGet = () => new ShimSPGroupCollection().Bind(
                        new SPGroup[]
                        {
                            new ShimSPGroup()
                            {
                                CanCurrentUserEditMembershipGet = () => true,
                                RemoveUserSPUser = user => actualUserRemoved= true
                            }
                        }),
                    UrlGet = () => DummyUrl
                }
            };

            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                actualUrl = url;
                actualRedirectFlag = flags;
                actualRedirect = true;
                return true;
            };

            var eventArgsSend = new ShimGridViewCommandEventArgs()
            {
            };

            var commandEventArgs = new ShimCommandEventArgs(eventArgsSend)
            {
                CommandNameGet = () => "Del",
                CommandArgumentGet = () => DummyString
            };

            // Act
            _privateObject.Invoke(GridView1RowCommandMethodName, this, eventArgsSend.Instance);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualUrl.ShouldBe("epmlive/sitepermissions.aspx?"),
                () => actualRedirectFlag.ShouldBe(SPRedirectFlags.RelativeToLayoutsPage),
                () => actualRedirect.ShouldBeTrue());
        }

        [TestMethod]
        public void GridViewRowCommand_CommandEdiIsAdminTrueCanEditTrue_RemoveUserRedirect()
        {
            // Arrange

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    AllUsersGet = () => new ShimSPUserCollection()
                    {
                        ItemGetString = itemName => new ShimSPUser()
                        {
                            IsSiteAdminGet = () => true,
                            NameGet = () => DummyUserNameName,
                            EmailGet = () => DummyUserEmail,
                            GroupsGet = () => new ShimSPGroupCollection().Bind(
                                new SPGroup[]
                                {
                                    new ShimSPGroup()
                                    {
                                        NameGet = () => DummyGroupName
                                    }
                                })
                        }
                    },
                    UserIsSiteAdminGet = () => true,
                    GroupsGet = () => new ShimSPGroupCollection().Bind(
                        new SPGroup[]
                        {
                            new ShimSPGroup()
                            {
                                NameGet = () => DummyGroupName
                            },
                            new ShimSPGroup()
                            {
                                NameGet = () => DummyGroupName2
                            }
                        }),
                    SiteGroupsGet = () => new ShimSPGroupCollection()
                    {
                        ItemGetString = itemName => new ShimSPGroup()
                        {
                            CanCurrentUserEditMembershipGet = () => true
                        }
                    }
                }
            };

            _privateObject.SetField(HiddenUsernameFieldName, new HiddenField());

            var eventArgsSend = new ShimGridViewCommandEventArgs()
            {
            };

            var commandEventArgs = new ShimCommandEventArgs(eventArgsSend)
            {
                CommandNameGet = () => "Edi",
                CommandArgumentGet = () => DummyUserName
            };

            // Act
            _privateObject.Invoke(GridView1RowCommandMethodName, this, eventArgsSend.Instance);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _labelName.Text.ShouldBe(DummyUserNameName),
                () => _labelUserName.Text.ShouldBe(DummyUserName),
                () => _labelEmail.Text.ShouldBe(DummyUserEmail),
                () => ((LiteralControl)_panelGroups.Controls[0]).Text.ShouldBe("<input type=\"checkbox\" name=\"Groups\" checked value=\"@\"> Site Collection Administrator"),
                () => ((LiteralControl)_panelGroups.Controls[1]).Text.ShouldBe("<br>"),
                () => ((LiteralControl)_panelGroups.Controls[2]).Text.ShouldBe($"<input type=\"checkbox\" name=\"Groups\" checked value=\"{DummyGroupName}\">{DummyGroupName}"),
                () => ((LiteralControl)_panelGroups.Controls[3]).Text.ShouldBe("<br>"),
                () => ((LiteralControl)_panelGroups.Controls[4]).Text.ShouldBe($"<input type=\"checkbox\" name=\"Groups\" value=\"{DummyGroupName2}\">{DummyGroupName2}"),
                () => ((LiteralControl)_panelGroups.Controls[5]).Text.ShouldBe("<br>"));
        }

        [TestMethod]
        public void GridViewRowCommand_CommandEdiIsAdminFalseCanEditFalse_RemoveUserRedirect()
        {
            // Arrange

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    AllUsersGet = () => new ShimSPUserCollection()
                    {
                        ItemGetString = itemName => new ShimSPUser()
                        {
                            IsSiteAdminGet = () => false,
                            NameGet = () => DummyUserNameName,
                            EmailGet = () => DummyUserEmail,
                            GroupsGet = () => new ShimSPGroupCollection().Bind(
                                new SPGroup[]
                                {
                                    new ShimSPGroup()
                                    {
                                        NameGet = () => DummyGroupName
                                    }
                                })
                        }
                    },
                    UserIsSiteAdminGet = () => true,
                    GroupsGet = () => new ShimSPGroupCollection().Bind(
                        new SPGroup[]
                        {
                            new ShimSPGroup()
                            {
                                NameGet = () => DummyGroupName
                            },
                            new ShimSPGroup()
                            {
                                NameGet = () => DummyGroupName2
                            }
                        }),
                    SiteGroupsGet = () => new ShimSPGroupCollection()
                    {
                        ItemGetString = itemName => new ShimSPGroup()
                        {
                            CanCurrentUserEditMembershipGet = () => false
                        }
                    }
                }
            };


            _privateObject.SetField(HiddenUsernameFieldName, new HiddenField());

            var eventArgsSend = new ShimGridViewCommandEventArgs()
            {
            };

            var commandEventArgs = new ShimCommandEventArgs(eventArgsSend)
            {
                CommandNameGet = () => "Edi",
                CommandArgumentGet = () => DummyUserName
            };

            // Act
            _privateObject.Invoke(GridView1RowCommandMethodName, this, eventArgsSend.Instance);

            // Assert
            LoadFields();

            this.ShouldSatisfyAllConditions(
                () => _labelName.Text.ShouldBe(DummyUserNameName),
                () => _labelUserName.Text.ShouldBe(DummyUserName),
                () => _labelEmail.Text.ShouldBe(DummyUserEmail),
                () => ((LiteralControl)_panelGroups.Controls[0]).Text.ShouldBe("<input type=\"checkbox\" name=\"Groups\" value=\"@\"> Site Collection Administrator"),
                () => ((LiteralControl)_panelGroups.Controls[1]).Text.ShouldBe("<br>"),
                () => ((LiteralControl)_panelGroups.Controls[2]).Text.ShouldBe($"<input type=\"checkbox\" name=\"Groups\" checked value=\"{DummyGroupName}\" disabled>{DummyGroupName}"),
                () => ((LiteralControl)_panelGroups.Controls[3]).Text.ShouldBe("<br>"),
                () => ((LiteralControl)_panelGroups.Controls[4]).Text.ShouldBe($"<input type=\"checkbox\" name=\"Groups\" value=\"{DummyGroupName2}\" disabled>{DummyGroupName2}"),
                () => ((LiteralControl)_panelGroups.Controls[5]).Text.ShouldBe("<br>"));
        }

        [TestMethod]
        public void Button2Click_SetSiteAdminTrue_SetUserSiteAdminTrueRedirect()
        {
            // Arrange
            var actualUrl = string.Empty;
            var actualRedirectFlag = SPRedirectFlags.Default;
            var actualRedirect = false;
            var actualUserAdded = false;
            var actualSiteAdmin = false;

            var siteGroup = new ShimSPGroup()
            {
                NameGet = () => DummyGroupName2,
                CanCurrentUserEditMembershipGet = () => true
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    AllUsersGet = () => new ShimSPUserCollection()
                    {
                        ItemGetString = itemName => new ShimSPUser()
                        {
                            GroupsGet = () => new ShimSPGroupCollection().Bind(
                            new SPGroup[]
                            {
                                new ShimSPGroup()
                                {
                                    NameGet = () => DummyGroupName
                                }
                            }),
                            IsSiteAdminSetBoolean = siteAdmin => actualSiteAdmin = siteAdmin
                        }
                    },
                    GroupsGet = () => new ShimSPGroupCollection()
                    {
                        ItemGetString = itemName => new ShimSPGroup()
                        {
                            NameGet = () => DummyGroupName,
                            AddUserSPUser = user => actualUserAdded = true
                        }
                    },
                    SiteGroupsGet = () => new ShimSPGroupCollection()
                    {
                        ItemGetString = itemName => siteGroup
                    }.Bind(
                        new SPGroup[]
                        {
                            siteGroup
                        }),
                    UserIsSiteAdminGet = () => true
                },
                SiteGet = () => new ShimSPSite()
                {
                    UrlGet = () => DummyUrl
                }
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName => $"{DummyGroupName},@"
            };


            _privateObject.SetField(HiddenUsernameFieldName, new HiddenField()
            {
                Value = DummyUserName
            });

            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                actualUrl = url;
                actualRedirectFlag = flags;
                actualRedirect = true;
                return true;
            };

            // Act
            _privateObject.Invoke(Button2ClickMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualUserAdded.ShouldBeTrue(),
                () => actualSiteAdmin.ShouldBeTrue(),
                () => actualUrl.ShouldBe("epmlive/sitepermissions.aspx?"),
                () => actualRedirectFlag.ShouldBe(SPRedirectFlags.RelativeToLayoutsPage),
                () => actualRedirect.ShouldBeTrue());
        }

        [TestMethod]
        public void Button2Click_SetSiteAdminFalse_SetUserSiteAdminTrueRedirect()
        {
            // Arrange
            var actualUrl = string.Empty;
            var actualRedirectFlag = SPRedirectFlags.Default;
            var actualRedirect = false;
            var actualUserAdded = false;
            var actualSiteAdmin = false;

            var siteGroup = new ShimSPGroup()
            {
                NameGet = () => DummyGroupName2,
                CanCurrentUserEditMembershipGet = () => true
            };

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    AllUsersGet = () => new ShimSPUserCollection()
                    {
                        ItemGetString = itemName => new ShimSPUser()
                        {
                            GroupsGet = () => new ShimSPGroupCollection().Bind(
                            new SPGroup[]
                            {
                                new ShimSPGroup()
                                {
                                    NameGet = () => DummyGroupName
                                }
                            }),
                            IsSiteAdminSetBoolean = siteAdmin => actualSiteAdmin = siteAdmin
                        }
                    },
                    GroupsGet = () => new ShimSPGroupCollection()
                    {
                        ItemGetString = itemName => new ShimSPGroup()
                        {
                            NameGet = () => DummyGroupName,
                            AddUserSPUser = user => actualUserAdded = true
                        }
                    },
                    SiteGroupsGet = () => new ShimSPGroupCollection()
                    {
                        ItemGetString = itemName => siteGroup
                    }.Bind(
                        new SPGroup[]
                        {
                            siteGroup
                        }),
                    UserIsSiteAdminGet = () => true
                },
                SiteGet = () => new ShimSPSite()
                {
                    UrlGet = () => DummyUrl
                }
            };

            ShimPage.AllInstances.RequestGet = sender => new ShimHttpRequest()
            {
                ItemGetString = itemName => $"{DummyGroupName}"
            };


            _privateObject.SetField(HiddenUsernameFieldName, new HiddenField()
            {
                Value = DummyUserName
            });

            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                actualUrl = url;
                actualRedirectFlag = flags;
                actualRedirect = true;
                return true;
            };

            // Act
            _privateObject.Invoke(Button2ClickMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualUserAdded.ShouldBeTrue(),
                () => actualSiteAdmin.ShouldBeFalse(),
                () => actualUrl.ShouldBe("epmlive/sitepermissions.aspx?"),
                () => actualRedirectFlag.ShouldBe(SPRedirectFlags.RelativeToLayoutsPage),
                () => actualRedirect.ShouldBeTrue());
        }

        [TestMethod]
        public void Button3Click_Should_Redirect()
        {
            // Arrange
            var actualUrl = string.Empty;
            var actualRedirectFlag = SPRedirectFlags.Default;
            var actualRedirect = false;

            ShimSPContext.CurrentGet = () => new ShimSPContext()
            {
                WebGet = () => new ShimSPWeb()
                {
                    UrlGet = () => DummyUrl
                }
            };

            ShimSPUtility.RedirectStringSPRedirectFlagsHttpContext = (url, flags, context) =>
            {
                actualUrl = url;
                actualRedirectFlag = flags;
                actualRedirect = true;
                return true;
            };

            // Act
            _privateObject.Invoke(Button3ClickMethodName, this, EventArgs.Empty);

            // Assert
            this.ShouldSatisfyAllConditions(
                () => actualUrl.ShouldBe("epmlive/sitepermissions.aspx?"),
                () => actualRedirectFlag.ShouldBe(SPRedirectFlags.RelativeToLayoutsPage),
                () => actualRedirect.ShouldBeTrue());
        }

        private void LoadFields()
        {
            _labelDesc = (Label)_privateObject.GetField(LabelDescFieldName);
            _labelTitle = (Label)_privateObject.GetField(LabelTitleFieldName);
            _labelName = (Label)_privateObject.GetField(LabelNameFieldName);
            _labelUserName = (Label)_privateObject.GetField(LabelUserNameFieldName);
            _labelEmail = (Label)_privateObject.GetField(LabelEmailFieldName);
            _gridView1 = (GridView)_privateObject.GetField(GridView1FieldName);
            _panelGroups = (Panel)_privateObject.GetField(PanelGroupdsFieldName);
        }
    }
}
