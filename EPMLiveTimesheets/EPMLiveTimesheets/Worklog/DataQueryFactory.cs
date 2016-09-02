using System;
using System.Collections.Generic;
using Microsoft.SharePoint;

namespace TimeSheets
{

    public class DataQueryFactory
    {
        #region BaseType enum

        public enum BaseType
        {
            GenericList = 0,
            DocumentLibrary = 1,
            DiscussionForum = 3,
            VoteOrSurvey = 4,
            IssuesList = 5
        }

        #endregion

        #region Scope enum

        public enum Scope
        {
            Current,
            Recursive,
            SiteCollection
        }

        #endregion

        private List<Guid> _listIds = new List<Guid>();
        private BaseType _listType = BaseType.GenericList;
        private string _query = "";
        private List<string> _viewFields = new List<string>();
        private Scope _webs = Scope.Current;

        public List<Guid> ListIds
        {
            get { return _listIds; }
            set { _listIds = value; }
        }

        public BaseType ListType
        {
            get { return _listType; }
            set { _listType = value; }
        }

        public List<string> ViewFields
        {
            get { return _viewFields; }
            set { _viewFields = value; }
        }

        public string Query
        {
            get { return _query; }
            set { _query = value; }
        }

        public Scope Webs
        {
            get { return _webs; }
            set { _webs = value; }
        }

        public SPSiteDataQuery DataQuery
        {
            get
            {
                SPSiteDataQuery q = new SPSiteDataQuery();
                ConstructDataQuery(q);
                return q;
            }
        }

        public void ConstructDataQuery(SPSiteDataQuery q)
        {
            if (_listIds.Count == 0)
                q.Lists = string.Format("<Lists BaseType='{0}'/>", (int)_listType);
            else
            {
                string lists = "<Lists>";
                foreach (Guid listId in _listIds)
                    lists += string.Format("<List ID='{0}' />", listId);
                lists += "</Lists>";
                q.Lists = lists;
            }
            q.Query = _query;
            if (_webs != Scope.Current)
                q.Webs = string.Format("<Webs Scope='{0}' />", _webs);
            if (_viewFields.Count > 0)
            {
                string viewFields = "";
                foreach (string viewField in _viewFields)
                {
                    viewFields += string.Format("<FieldRef Name='{0}'/>", viewField);
                }
                q.ViewFields = viewFields;
            }
        }
    }
}