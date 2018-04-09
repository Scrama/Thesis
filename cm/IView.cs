using System;
using System.Collections.Generic;

namespace cm
{
    public interface IView
    {
        event EventHandler Load;
        event EventHandler Closed;
        event EventHandler FilesAdding;
        event EventHandler<int> FilesRemoving;
        event EventHandler<int> FileUp;
        event EventHandler<int> FileDown;
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
    }
}