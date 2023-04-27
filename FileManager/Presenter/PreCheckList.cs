using FileManager.Model;
using FileManager.Model.@interface;
using FileManager.View.@interface;
using System;
using System.Windows.Forms;

namespace FileManager.Presenter
{
    internal class PreCheckList
    {
        readonly InFcMain view;
        readonly InFcCheckList model;
        readonly InFcLog log;
        public PreCheckList(InFcMain view, InFcCheckList model, InFcLog log)
        {
            this.view = view;
            this.model = model;
            this.log = new MdLog();
            model.treeview = view.treeview;
            model.DeleteListBox = view.DeleteListBox;
        }

        public void SuperPathToTreeView() /* SuperPath를 기준으로 TreeView 생성 */
        {
            log.LogBox = view.LogBox;
            if (!model.MakeTreeView()) MessageBox.Show("Try again");
            log.LogPrint(model.SuperPath, 2);
            log.LogPrint(string.Empty, 3);
            if (model.DeleteDirList.Count > 0) { log.LogPrint(string.Empty, 7); }
            GC.Collect();   //가비지 컬렉터
        }

        public void TreViewtoDeleteList() /* TreeView를 기준으로 DeleteListBox 생성 */
        {
            model.ListRefresh();
            if (model.DeleteDirList.Count > 0) { log.LogPrint(string.Empty, 7); }
            GC.Collect();   //가비지 컬렉터
        }
        public void ControllerChildrenNode(TreeViewEventArgs e)
        {
            var node = e.Node;
            var children = node.Nodes;
            for (int K = 0; K < children.Count; K++) { children[K].Checked = node.Checked; }
        }
    }
}
