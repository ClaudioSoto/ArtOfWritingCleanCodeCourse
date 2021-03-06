using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;

namespace CleanCode.FullRefactoring
{
    public class PostControl : System.Web.UI.UserControl
    {
        private readonly Project.UserControls.PostRepository _postRepository;
        private readonly PostValidator _validator;
        private Label PostBody { get; set; }
        private Label PostTitle { get; set; }
        private int? PostId { get; set; }

        public PostControl()
        {
            _postRepository = new Project.UserControls.PostRepository();
            _validator = new PostValidator();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Page.IsPostBack)
            
                TrySavePost();
            else
                DisplayPost();
        }

        private void TrySavePost()
        {
            var post = CreateNewPost();
            var results = _validator.Validate(post);

            if (results.IsValid)
            {
                _postRepository.SavePost(post);
            }
            else
            {
                DisplayErrors(results);
            }
        }

        private void DisplayPost()
        {
            int postId = Convert.ToInt32(Request.QueryString["id"]);
            var post = _postRepository.GetPost(postId);
            PostBody.Text = post.Body;
            PostTitle.Text = post.Title;
        }

        private Post CreateNewPost()
        {
            return new Post()
            {
                Id = Convert.ToInt32(PostId.Value),
                Title = PostTitle.Text.Trim(),
                Body = PostBody.Text.Trim()
            };
        }

        private void DisplayErrors(ValidationResult results)
        {
            var errorLog = GetSummaryErrorControl();

            foreach (var error in results.Errors)
            {
                if (!GetErrorLabel(error, out var errorMessage)) 
                    errorLog.Items.Add(new ListItem(error.ErrorMessage));
                else
                    errorMessage.Text = error.ErrorMessage;
            }
        }
        private BulletedList GetSummaryErrorControl()
        {
            return (BulletedList)FindControl("ErrorSummary");
        }

        private bool GetErrorLabel(ValidationError error, out Label label)
        {
            label = null;
            return FindControl(error.PropertyName + "Error") is Label;
        }

    }

    #region helpers

    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IEnumerable<ValidationError> Errors { get; set; }
    }

    public class ValidationError
    {
        public string PropertyName { get; set; }
        public string ErrorMessage { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }

    public class PostValidator
    {
        public ValidationResult Validate(Post entity)
        {
            throw new NotImplementedException();
        }
    }

    public class DbSet<T> : IQueryable<T>
    {
        public void Add(T entity)
        {
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public Expression Expression
        {
            get { throw new NotImplementedException(); }
        }

        public Type ElementType
        {
            get { throw new NotImplementedException(); }
        }

        public IQueryProvider Provider
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class PostDbContext
    {
        public DbSet<Post> Posts { get; set; }

        public void SaveChanges()
        {
        }
    }
    #endregion

}