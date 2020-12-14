using System;
using System.Collections.Generic;
using System.Text;

namespace HarToFiles.Model
{
    /// <summary>
    /// harファイルのデータモデル。
    /// </summary>
    public class Har
    {
        public Log log { get; set; }
    }

    public class Log
    {
        public string version { get; set; }
        public Creator creator { get; set; }
        public Page[] pages { get; set; }
        public List<Entry> entries { get; set; }
    }

    public class Creator
    {
        public string name { get; set; }
        public string version { get; set; }
    }

    public class Page
    {
        public DateTime startedDateTime { get; set; }
        public string id { get; set; }
        public string title { get; set; }
        public Pagetimings pageTimings { get; set; }
    }

    public class Pagetimings
    {
        public float onContentLoad { get; set; }
        public float onLoad { get; set; }
    }

    public class Entry
    {
        public _Initiator _initiator { get; set; }
        public string _priority { get; set; }
        public string _resourceType { get; set; }
        public Cache cache { get; set; }
        public string pageref { get; set; }
        public Request request { get; set; }
        public Response response { get; set; }
        public string serverIPAddress { get; set; }
        public DateTime startedDateTime { get; set; }
        public float time { get; set; }
        public Timings timings { get; set; }
        public string _fromCache { get; set; }
        public string connection { get; set; }
    }

    public class _Initiator
    {
        public string type { get; set; }
        public Stack stack { get; set; }
        public string url { get; set; }
        public int lineNumber { get; set; }
    }

    public class Stack
    {
        public Callframe5[] callFrames { get; set; }
        public Parent parent { get; set; }
        public Parentid3 parentId { get; set; }
    }

    public class Parent
    {
        public string description { get; set; }
        public Callframe4[] callFrames { get; set; }
        public Parent1 parent { get; set; }
    }

    public class Parent1
    {
        public string description { get; set; }
        public Callframe3[] callFrames { get; set; }
        public Parentid parentId { get; set; }
        public Parent2 parent { get; set; }
    }

    public class Parentid
    {
        public string id { get; set; }
        public string debuggerId { get; set; }
    }

    public class Parent2
    {
        public string description { get; set; }
        public Callframe2[] callFrames { get; set; }
        public Parent3 parent { get; set; }
        public Parentid2 parentId { get; set; }
    }

    public class Parent3
    {
        public string description { get; set; }
        public Callframe1[] callFrames { get; set; }
        public Parent4 parent { get; set; }
    }

    public class Parent4
    {
        public string description { get; set; }
        public Callframe[] callFrames { get; set; }
        public Parentid1 parentId { get; set; }
    }

    public class Parentid1
    {
        public string id { get; set; }
        public string debuggerId { get; set; }
    }

    public class Callframe
    {
        public string functionName { get; set; }
        public string scriptId { get; set; }
        public string url { get; set; }
        public int lineNumber { get; set; }
        public int columnNumber { get; set; }
    }

    public class Callframe1
    {
        public string functionName { get; set; }
        public string scriptId { get; set; }
        public string url { get; set; }
        public int lineNumber { get; set; }
        public int columnNumber { get; set; }
    }

    public class Parentid2
    {
        public string id { get; set; }
        public string debuggerId { get; set; }
    }

    public class Callframe2
    {
        public string functionName { get; set; }
        public string scriptId { get; set; }
        public string url { get; set; }
        public int lineNumber { get; set; }
        public int columnNumber { get; set; }
    }

    public class Callframe3
    {
        public string functionName { get; set; }
        public string scriptId { get; set; }
        public string url { get; set; }
        public int lineNumber { get; set; }
        public int columnNumber { get; set; }
    }

    public class Callframe4
    {
        public string functionName { get; set; }
        public string scriptId { get; set; }
        public string url { get; set; }
        public int lineNumber { get; set; }
        public int columnNumber { get; set; }
    }

    public class Parentid3
    {
        public string id { get; set; }
        public string debuggerId { get; set; }
    }

    public class Callframe5
    {
        public string functionName { get; set; }
        public string scriptId { get; set; }
        public string url { get; set; }
        public int lineNumber { get; set; }
        public int columnNumber { get; set; }
    }

    public class Cache
    {
    }

    public class Request
    {
        public string method { get; set; }
        public string url { get; set; }
        public string httpVersion { get; set; }
        public Header[] headers { get; set; }
        public Querystring[] queryString { get; set; }
        public Cooky[] cookies { get; set; }
        public int headersSize { get; set; }
        public int bodySize { get; set; }
        public Postdata postData { get; set; }
    }

    public class Postdata
    {
        public string mimeType { get; set; }
        public string text { get; set; }
        public Param[] _params { get; set; }
    }

    public class Param
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Header
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Querystring
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Cooky
    {
        public string name { get; set; }
        public string value { get; set; }
        public object expires { get; set; }
        public bool httpOnly { get; set; }
        public bool secure { get; set; }
    }

    public class Response
    {
        public int status { get; set; }
        public string statusText { get; set; }
        public string httpVersion { get; set; }
        public Header1[] headers { get; set; }
        public Cooky1[] cookies { get; set; }
        public Content content { get; set; }
        public string redirectURL { get; set; }
        public int headersSize { get; set; }
        public int bodySize { get; set; }
        public int _transferSize { get; set; }
        public string _error { get; set; }
    }

    public class Content
    {
        public int size { get; set; }
        public string mimeType { get; set; }
        public string text { get; set; }
        public string encoding { get; set; }
    }

    public class Header1
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class Cooky1
    {
        public string name { get; set; }
        public string value { get; set; }
        public string path { get; set; }
        public string domain { get; set; }
        public DateTime? expires { get; set; }
        public bool httpOnly { get; set; }
        public bool secure { get; set; }
        public string sameSite { get; set; }
    }

    public class Timings
    {
        public float blocked { get; set; }
        public float dns { get; set; }
        public float ssl { get; set; }
        public float connect { get; set; }
        public float send { get; set; }
        public float wait { get; set; }
        public float receive { get; set; }
        public float _blocked_queueing { get; set; }
    }

}
