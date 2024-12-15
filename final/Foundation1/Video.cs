class Video
{
    //attributes (member variables)

    public string _title;

    public string _author;

    public int _length;

    public List<Comment> _comments = new();

    //behaviors (member functions or *methods*)

    public int GetCommentCount()
    {
        return _comments.Count();
    }

}