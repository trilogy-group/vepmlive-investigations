using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WorkEnginePPM
{
    class tagItem : IComparable<tagItem>
    {
        public tagItem ListNext = null;
        public tagItem ConsNext = null;
        public int ItemVal = 0, Group1 = 0, Group2 = 0, Group3 = 0;
        public string sVal = "";
        public string sDVal = "";

        public int CompareTo(tagItem rhs)
        {
            return this.sVal.CompareTo(rhs.sVal);
        }
    };

    class Consolid
    {
        public Consolid Parent = null;
        public Consolid Sibling = null;
        public Consolid Oldest = null;
        public Consolid Next = null;
        public Consolid Group2 = null;
        public Consolid Group3 = null;
        public GroupField GroupNode = null;
        public Consolid ItemNodeHead = null;
        public Consolid ItemNodeTail = null;
        public Consolid FinalList = null;
        public tagItem ItemPtr = null;
        public int level = 0;
        public bool bDone = false;
        public string elementName = "";
    };

    class GroupField : IComparable<GroupField>
    {
        public GroupField HashNext = null;
        public GroupField ListNext = null;
        public GroupField Parent = null;
        public GroupField Sibling = null;
        public GroupField Oldest = null;
        public GroupField Youngest = null;
        public Consolid link2cons = null;
        public int num_children = 0, sib_rank = 0, sib_level = 0;
        public GroupField BackwardPath = null;
        public int Group = 0, Parent_UID = 0, This_UID = 0;
        public string sVal = "";
        public string sDVal = "";

        public int CompareTo(GroupField rhs)
        {
            return this.sVal.CompareTo(rhs.sVal);
        }
    };

    public class SortAndGroup
    {
        List<GroupField> Group1 = null;
        List<GroupField> Group2 = null;
        List<GroupField> Group3 = null;
        List<GroupField> GroupHead1 = null;
        List<GroupField> GroupHead2 = null;
        List<GroupField> GroupHead3 = null;

        List<tagItem> Items = null;

        List<Consolid> Consolidate = null;

        Dictionary<int, GroupField > Sorted1 = null;
        Dictionary<int,GroupField > Sorted2 = null;
        Dictionary<int, GroupField > Sorted3 = null;

        public void NewGrouping()
        {
            Group1 = new List<GroupField>();
            Group2 = new List<GroupField>();
            Group3 = new List<GroupField>();

            GroupHead1 = new List<GroupField>();
            GroupHead2 = new List<GroupField>();
            GroupHead3 = new List<GroupField>();

            Items = new List<tagItem>();

            Consolidate = new List<Consolid>();

            Sorted1 = new Dictionary<int, GroupField>();
            Sorted2 = new Dictionary<int, GroupField>();
            Sorted3 = new Dictionary<int, GroupField>();

        }

        public void FinishedWithGrouping()
        {
            Group1 = null;
            Group2 = null;
            Group3 = null;

            GroupHead1 = null;
            GroupHead2 = null;
            GroupHead3 = null;

            Items = null;

            Consolidate = null;

            Sorted1 = null;
            Sorted2 = null;
            Sorted3 = null;
        }

        public void DefineItemValues(int ItemValue, int grp1Val, int grp2Val, int grp3Val, string ElStr, string ElDStr)
        {
            tagItem itm = new tagItem();

            itm.ItemVal = ItemValue;
            itm.Group1 = grp1Val;
            itm.Group2 = grp2Val;
            itm.Group3 = grp3Val;
             
            itm.sVal =  ElStr;
            itm.sDVal =  ElDStr;

            Items.Add(itm);
       }

        public void SortItems(int sortorder)
        {
            List<tagItem> Working = null;
            tagItem itm = null;
            int i;

            Working = Items;
            Working.Sort();

            Items = new List<tagItem>();

            if (sortorder <= 0)
            {
                for (i = Working.Count - 1; i >= 0; i--)
                {
                    itm = Working.ElementAt(i);

                    Items.Add(itm);
                }
            }
            else
            {
                for (i = 0; i <= Working.Count - 1; i++)
                {
                    itm = Working.ElementAt(i);

                    Items.Add(itm);
                }
            }
        }

        public void DefineGroupingValue(int group, int parval, int thisval, string ElStr, string ElDStr)
        {
            GroupField grp = new GroupField();

            grp.Parent_UID = parval;
            grp.This_UID = thisval;
            grp.sVal = ElStr;
            grp.sDVal = ElDStr;
            grp.Group = group;

            if (group == 1)
                Group1.Add(grp);
            else
            {
                if (group == 2)
                    Group2.Add(grp);
                else
                {
                    if (group == 3)
                        Group3.Add(grp);
                }
            }

        }

        public void SortGroup(int group, int sortorder)
        {
            List<GroupField> Working = null;
            Dictionary<int, GroupField> Sorted = new Dictionary<int, GroupField>();
            GroupField grp = null;
            int i;

            if (group == 1)
                Working = Group1;
            else
            {
                if (group == 2)
                    Working = Group2;
                else
                {
                    if (group == 3)
                        Working = Group3;
                    else
                        return;
                }
            }

            Working.Sort();

            if (sortorder <= 0)
            {
                for (i = Working.Count - 1; i >= 0; i--)
                {
                    grp = Working.ElementAt(i);

                    Sorted.Add(grp.This_UID,grp);
                }
            }
            else
            {
                for (i = 0; i <= Working.Count - 1; i++)
                {
                    grp = Working.ElementAt(i);

                    Sorted.Add(grp.This_UID,grp);
                }
            }

            if (group == 1)
                Sorted1 = Sorted;
            else if (group == 2)
                Sorted2 = Sorted;
            else if (group == 3)
                Sorted3 = Sorted;
            else
                return;

        }

        public void DoNotSortGroup(int group)
        {

            List<GroupField> Working = null;
            Dictionary<int, GroupField> Sorted = new Dictionary<int, GroupField>();
            GroupField grp = null;

            int i;

            if (group == 1)
                Working = Group1;
            else
            {
                if (group == 2)
                    Working = Group2;
                else
                {
                    if (group == 3)
                        Working = Group3;
                    else
                        return;
                }
            }

            for (i = 0; i <= Working.Count - 1; i++)
            {
                grp = Working.ElementAt(i);

                Sorted.Add(grp.This_UID, grp);
            }

            if (group == 1)
                Sorted1 = Sorted;
            else if (group == 2)
                Sorted2 = Sorted;
            else if (group == 3)
                Sorted3 = Sorted;
            else
                return;

        }
        
        public int CalculateGrouplingList(int fullpathflag, int GroupToLevel)
        {
            int i;
            List<GroupField> Working = null;
            List<GroupField> GroupHead = null;
            Dictionary<int, GroupField> Sorted = null;
            GroupField grp1_no_val = null;
            GroupField tmpgrp = null;
            GroupField grp2path = null;
            GroupField grp3path = null;
            
            //tagItem itm = null;
            Consolid tmp_cons = null;
            Consolid consol = null;
            Consolid curr_cons = null;
            Consolid prev_consol = null;
            Consolid con_head = null;
            Consolid con_tail = null;

            GroupField par_grp = null;

            if (GroupToLevel > 3)
                GroupToLevel = 3;
            else if (GroupToLevel < 0)
                GroupToLevel = 0;

            for (i = 1; i <= 3; i++)
            {

                switch (i)
                {
                    case 1:
                        Working = Group1;
                        GroupHead = GroupHead1;
                        Sorted = Sorted1;
                        break;
                    case 2:
                        Working = Group2;
                        GroupHead = GroupHead2;
                        Sorted = Sorted2;
                        break;
                    case 3:
                        Working = Group3;
                        GroupHead = GroupHead3;
                        Sorted = Sorted3;
                        break;
                }

                foreach (GroupField lgrp in Working)
                {

                    if (lgrp.Parent_UID == 0)
                    {
                        GroupHead.Add(lgrp);
                        lgrp.sib_rank = GroupHead.Count;

                        lgrp.sib_level = 1;
                    }
                    else
                    {
                        if (Sorted.TryGetValue(lgrp.Parent_UID,out par_grp) == true) 
                        {

                            lgrp.Parent = par_grp;

                            if (par_grp.Oldest == null)
                                par_grp.Oldest = lgrp;
                            else
                                par_grp.Youngest.Sibling = lgrp;

                            par_grp.Youngest = lgrp;
                        }
                    }
                }

                foreach (GroupField lgrp in GroupHead)
                {
                    SetLevels(lgrp);
                }
            }

            if (GroupToLevel == 0)
            {
                foreach ( tagItem litm in Items)
                {
                    consol = new Consolid();
                    consol.Parent = null;
                    consol.Sibling = null;
                    consol.Oldest = null;
                    consol.Group2 = null;
                    consol.Group3 = null;
                    consol.ItemNodeHead = null;
                    consol.ItemPtr = litm;
                    consol.GroupNode = null;
                    consol.FinalList = null;
                    consol.level = 1;

                    Consolidate.Add(consol);

                }

                return 1;
            }

            foreach (GroupField curr in GroupHead1)
            {
                curr_cons = new Consolid();

                if (prev_consol != null)
                    prev_consol.Sibling = curr_cons;
                else
                    con_head = curr_cons;

                prev_consol = curr_cons;
                Consolidate.Add(curr_cons);

                curr_cons.Parent = null;
                curr_cons.Sibling = null;
                curr_cons.Oldest = null;
                curr_cons.Group2 = null;
                curr_cons.Group3 = null;
                curr_cons.ItemNodeHead = null;
                curr_cons.ItemPtr = null;
                curr_cons.Next = null;
                curr_cons.GroupNode = curr;
                curr.link2cons = curr_cons;
                curr_cons.level = 1;
                curr_cons.elementName = curr.sDVal;

                CopyGroupSubTree(curr.Oldest, curr_cons, fullpathflag != 0);
                grp1_no_val = curr;
            }


            grp1_no_val.Sibling = new GroupField();
            grp1_no_val = grp1_no_val.Sibling;
            grp1_no_val.HashNext = null;
            grp1_no_val.ListNext = null;
            grp1_no_val.Parent = null;
            grp1_no_val.Sibling = null;
            grp1_no_val.Oldest = null;
            grp1_no_val.Group = 1;
            grp1_no_val.Youngest = null;
            grp1_no_val.BackwardPath = null;

            grp1_no_val.sDVal = "ZZZZZZZZZ";
            grp1_no_val.sVal = "";


            grp1_no_val.Parent_UID = 0;
            grp1_no_val.This_UID = 0;
            curr_cons.Sibling = new Consolid();
            curr_cons = curr_cons.Sibling;

            Consolidate.Add(curr_cons);


            curr_cons.elementName = grp1_no_val.sDVal;
            curr_cons.Parent = null;
            curr_cons.Sibling = null;
            curr_cons.Oldest = null;
            curr_cons.ItemNodeHead = null;
            curr_cons.ItemPtr = null;
            curr_cons.Group2 = null;
            curr_cons.Group3 = null;
            curr_cons.Next = null;
            curr_cons.GroupNode = grp1_no_val;

            grp1_no_val.link2cons = curr_cons;

            curr_cons.level = 1;

            int curr_uid;

            foreach (tagItem curr_item in Items)
            {
                curr_item.ConsNext = null;
                curr_uid = curr_item.Group1;

                if (Sorted1.TryGetValue(curr_item.Group1,out tmpgrp) == false)
                    tmpgrp = grp1_no_val;


                tmp_cons = tmpgrp.link2cons;

                grp2path = GetBackPath(2, curr_item.Group2, GroupToLevel);
                grp3path = GetBackPath(3, curr_item.Group3, GroupToLevel);

                if (grp2path != null)
                    tmp_cons = AddToCons(tmp_cons, grp2path, true, fullpathflag != 0);

                if (grp3path!= null)
                    tmp_cons = AddToCons(tmp_cons, grp3path, false, fullpathflag != 0);

                if (tmp_cons != null)
                {
                    if (tmp_cons.ItemNodeHead == null)
                    {
                        tmp_cons.ItemNodeHead = new Consolid();
                        curr_cons = tmp_cons.ItemNodeHead;
                    }
                    else
                    {
                        tmp_cons.ItemNodeTail.Sibling = new Consolid();
                        curr_cons = tmp_cons.ItemNodeTail.Sibling;
                    }

                    tmp_cons.ItemNodeTail = curr_cons;

                    curr_cons.Parent = tmp_cons;
                    curr_cons.Sibling = null;
                    curr_cons.Oldest = null;
                    curr_cons.Group2 = null;
                    curr_cons.Group3 = null;
                    curr_cons.ItemNodeHead = null;
                    curr_cons.ItemPtr = curr_item;
                    curr_cons.GroupNode = null;
                    curr_cons.level = tmp_cons.level + 1;
                }
            }


            FixUpAdditions(con_head);


            con_tail = con_head;
            curr_cons = con_head;

            while (curr_cons != null)
            {
                //		TRACE(L"ROOT LIST %s\n",curr_cons.elementName);
                Listify(curr_cons.Oldest, ref con_tail);
                con_tail.Next = curr_cons.Sibling;
                curr_cons = curr_cons.Sibling;
                con_tail = curr_cons;
            }

            Consolid m_confinalhead = null;
            Consolid m_confinaltail = null;

            curr_cons = con_head;

            int lastlevel = 0;
            bool doit;
            bool bLastGroupDone = false;


            while (curr_cons != null)
            {
                doit = false;
                if (curr_cons.GroupNode != null)
                {

                    bLastGroupDone = true;
                    if (curr_cons.GroupNode.Group <= GroupToLevel)
                    {
                        doit = true;
                        curr_cons.bDone = true;
                        lastlevel = curr_cons.level;
                    }
                    else
                    {
                        curr_cons.bDone = false;
                        bLastGroupDone = false;
                    }

                }
                else
                    doit = true;


                if (doit)
                {
                    if (m_confinalhead == null)
                        m_confinalhead = curr_cons;
                    else
                        m_confinaltail.FinalList = curr_cons;

                    m_confinaltail = curr_cons;
                    curr_cons.FinalList = null;


                   if (curr_cons.GroupNode == null)
                    {
                        if (bLastGroupDone)
                            curr_cons.level = lastlevel + 1;
                        else
                        {
                            tmp_cons = curr_cons.Parent;
                            curr_cons.level = 1;

                            while (tmp_cons != null)
                            {
                                if (tmp_cons.bDone)
                                {
                                    curr_cons.level = tmp_cons.level + 1;
                                    tmp_cons = null;
                                    break;
                                }
                                else
                                    tmp_cons = tmp_cons.Parent;
                            }
                        }

                    }
                }

                curr_cons = curr_cons.Next;
            }


            Consolidate = new List<Consolid>();

            curr_cons = m_confinalhead;

            while (curr_cons != null)
            {
                if (curr_cons.bDone || curr_cons.GroupNode == null) 
                    Consolidate.Add( curr_cons);
                curr_cons = curr_cons.Next;
            }

            return 1;
        }

        void SetLevels(GroupField curr_grp)
        {
            GroupField curr;
	        int j;


	        curr = curr_grp.Oldest;
	        j = 1;

	        while (curr != null)
	        {
		        curr.sib_level = curr_grp.sib_level + 1;
		        curr.sib_rank = j++;
		        SetLevels(curr);
		        curr = curr.Sibling;
	        }
        }

        void CopyGroupSubTree(GroupField curr_grp, Consolid curr_cons, bool bFullPath)
        {
            Consolid cons = null;

	        while (curr_grp != null)
	        {
		        if (curr_cons.Oldest == null)
		        {
			        curr_cons.Oldest = new Consolid();
			        cons = curr_cons.Oldest;
		        }
		        else
		        {
			        cons.Sibling = new Consolid();
			        cons = cons.Sibling;
		        }
		        cons.Parent = curr_cons;
		        cons.Sibling = null;
		        cons.Oldest = null;
		        cons.Group2 = null;
		        cons.Group3 = null;
		        cons.Next = null;
		        cons.ItemNodeHead = null;
		        cons.ItemPtr = null;
		        cons.GroupNode = curr_grp;

                if (bFullPath)
                    cons.elementName = curr_cons.elementName + "." + curr_grp.sDVal;
                else
                    cons.elementName = curr_grp.sDVal;

		        curr_grp.link2cons = cons;
		        cons.level = curr_cons.level + 1;

                Consolidate.Add(cons);

		        CopyGroupSubTree(curr_grp.Oldest,cons, bFullPath);

		        curr_grp = curr_grp.Sibling;
	        }

        }
        
        GroupField GetBackPath(int group, int grpval, int GroupToLevel)
        {
	        GroupField tmp;
            Dictionary<int, GroupField> Sorted = null;

            if (group == 1)
                Sorted = Sorted1;
            else if (group == 2)
                Sorted = Sorted2;
            else if (group == 3)
                Sorted = Sorted3;

            //if (GroupToLevel <= group)
            //    return null;

            if (Sorted.TryGetValue(grpval, out tmp) == false)
		        return  null;

	        tmp.BackwardPath = null;

	        while (tmp.Parent != null)
	        {
		        tmp.Parent.BackwardPath = tmp;
		        tmp = tmp.Parent;
	        }
        	
	        return tmp;
        }

        Consolid AddToCons(Consolid cons_root, GroupField grp_path, bool bUseGrp2, bool bFullPath)
        {
	        Consolid tmp_cons = null;
            Consolid tmp_root = null;
	        bool bFound;

	        tmp_root = (bUseGrp2) ? cons_root.Group2 : cons_root.Group3;

	        tmp_cons = tmp_root;
	        bFound = false;



	        while (tmp_cons != null && !bFound)
	        {
		        if (tmp_cons.GroupNode == grp_path)
			        bFound = true;
		        else
			        tmp_cons = tmp_cons.Sibling;
	        }

	        if (!bFound)
	        {

        //		TRACE(L"Not Found... so add %s\n",grp_path.sDVal);
		        tmp_cons = new Consolid();

		        tmp_cons.Parent = cons_root;
		        tmp_cons.Sibling = null;
		        tmp_cons.Oldest = null;
		        tmp_cons.Next = null;
		        tmp_cons.Group2 = null;
		        tmp_cons.Group3 = null;
		        tmp_cons.ItemNodeHead = null;
		        tmp_cons.ItemPtr = null;
		        tmp_cons.GroupNode = grp_path;
		        tmp_cons.level = cons_root.level + 1;

		        if (bFullPath) 
                    tmp_cons.elementName = cons_root.elementName + "." + grp_path.sDVal;
		        else
			        tmp_cons.elementName = grp_path.sDVal;

		        if (tmp_root == null)
		        {
			        if (bUseGrp2)
				        cons_root.Group2 = tmp_cons;
			        else
				        cons_root.Group3 = tmp_cons;
		        }
		        else
		        {
			        if (tmp_root.GroupNode.sib_rank > grp_path.sib_rank)
			        {
				        if (bUseGrp2)
				        {	
					        tmp_cons.Sibling = cons_root.Group2;
					        cons_root.Group2 = tmp_cons;
				        }
				        else
				        {
					        tmp_cons.Sibling = cons_root.Group3;
					        cons_root.Group3 = tmp_cons;
				        }
			        }
			        else
			        {
				        while (tmp_root.Sibling != null && tmp_root.Sibling.GroupNode.sib_rank < grp_path.sib_rank)
					        tmp_root = tmp_root.Sibling;

				        tmp_cons.Sibling = tmp_root.Sibling;
				        tmp_root.Sibling = tmp_cons;
			        }
		        }
	        }

	        // so by now tmp_cons points to the cons in the correct group list....
	        // so travere down the backpath to make sure all the "nodes" are there...


	        if (grp_path.BackwardPath != null)
		        return AddToCons(tmp_cons,grp_path.BackwardPath,bUseGrp2, bFullPath);
	        else
		        return tmp_cons;
        }
        
        void FixUpAdditions(Consolid cons_root)
        {

	        Consolid tmpold, cur_ins;

	        while (cons_root != null)
	        {
		        tmpold = cons_root.Oldest;
		        cur_ins = null;

		        // if there are items under here - insert them immediately before any "old" children...

		        if (cons_root.ItemNodeHead != null)
		        {

			        // point cur_ins to the oldes item....

			        cur_ins = cons_root.ItemNodeHead;

			        while (cur_ins != null && cur_ins.Sibling != null)
				        cur_ins = cur_ins.Sibling;

			        // set the root oldest to the oldest item...

			        cons_root.Oldest = cons_root.ItemNodeHead;

		        }
        			
		        // if we have g2 nodes then add them onto the end of the item list (if there...)

		        if (cons_root.Group2 != null)
		        {
			        if (cur_ins == null)
				        cons_root.Oldest = cons_root.Group2;
			        else
				        cur_ins.Sibling = cons_root.Group2;

			        // point cur_ins to the oldes g2 node....

			        cur_ins = cons_root.Group2;

			        while (cur_ins != null && cur_ins.Sibling != null)
				        cur_ins = cur_ins.Sibling;

		        }
		        // if we have g3 nodes then add them onto the end of the item list and g2 nodes(if there...)

		        if (cons_root.Group3 != null)
		        {
			        if (cur_ins == null)
				        cons_root.Oldest = cons_root.Group3;
			        else
				        cur_ins.Sibling = cons_root.Group3;

			        // point cur_ins to the oldes g3 node....

			        cur_ins = cons_root.Group3;

			        while (cur_ins != null && cur_ins.Sibling != null)
				        cur_ins = cur_ins.Sibling;

		        }
        			

		        // finally link back the "real" children onto the end of the item, g2 and g3 chains....

		        if (cur_ins != null)
			        cur_ins.Sibling = tmpold; 


		        FixUpAdditions(cons_root.Oldest);
		        cons_root = cons_root.Sibling;
	        }
        }

        void Listify(Consolid cons_root, ref Consolid cons_tail)
        {
            Consolid temp;

	        while (cons_root != null)
	        {
		        temp = cons_tail;
		        temp.Next = cons_root;
		        cons_tail = cons_root;

		        Listify(cons_root.Oldest,ref cons_tail);
		        cons_root = cons_root.Sibling;
	        }
        }

        public int ElementDetails(int element, ref int group, ref int uid, ref int level, ref int grp_level, ref string sVal)
        {
            Consolid consol = null;
            
            group = 0;
            uid = 0;
            level = 0;
            grp_level = 0;
            sVal = "";

            if (element <= 0)
                return -1;

            if (element > Consolidate.Count)
                return -1;

            consol = Consolidate.ElementAt(element - 1);

            if (consol.GroupNode != null)
            {
                group = consol.GroupNode.Group;
                uid = consol.GroupNode.This_UID;
                grp_level = consol.GroupNode.sib_level;

                sVal = consol.elementName;
            }
            else
            {
                sVal = consol.ItemPtr.sVal;
                uid = consol.ItemPtr.ItemVal;
            }


            level = consol.level;


            if (element == Consolidate.Count)
                return -1;

            return ++element;

        }


    };
}
