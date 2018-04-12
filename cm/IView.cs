using System;
using System.Collections.Generic;

namespace cm
{
    public interface IView
    {
        event EventHandler Load;
        event EventHandler Closed;
        event EventHandler FilesAdding;
        event EventHandler<ValueEventArg<int>> FilesRemoving;
        event EventHandler<ValueEventArg<int>> FileUp;
        event EventHandler<ValueEventArg<int>> FileDown;
        event EventHandler HeaderBrowsing;
        event EventHandler TargetBrowsing;
        event EventHandler Building;
        event EventHandler FilesSorting;
        void SetFiles(List<string> files);
        string[] GetFiles(string dir);
        void Select(int index);
        string RequestHeader(string dir);
        string RequestTarget(string dir, string filename);
        void ReleaseButtons(bool success, string log);
        string Header { get; set; }
        string Target { get; set; }
        void Log(string message);
    }
}