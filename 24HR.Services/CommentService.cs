using _24HourProject.Models;
using _24Hr.Models;
using _24HR.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24HR.Services
{
    public class CommentService
    {
        private readonly Guid _authorId;

        public CommentService(Guid authorId)
        {
            _authorId = authorId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity = new Comment()
            {
                AuthorId = _authorId,
                CommentText = model.CommentText,
                Id = model.Id

            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Comments
                    .Single(e => e.CommentId == id && e.AuthorId == _authorId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        CommentText = entity.CommentText,
                        Replies = entity.Replies
                    };
            }
        }
        public bool UpdateComment(CommentEdit model)
        {

            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Comments
                    .Single(e => e.CommentId == model.CommentId && e.AuthorId == _authorId);
                entity.CommentId = entity.CommentId;
                entity.CommentText = entity.CommentText;
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Comments
                    .Where(e => e.AuthorId == _authorId)
                    .Select(
                        e =>
                        new CommentListItem
                        {
                            CommentId = e.CommentId,
                            CommentText = e.CommentText
                        });
                return query.ToArray();
            }
        }
        public bool DeleteComment(int commentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Comments
                    .Single(e => e.CommentId == commentId && e.AuthorId == _authorId);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
