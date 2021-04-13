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
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;   
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                AuthorId = _userId,
                Title = model.Title,
                Text = model.Text,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
            

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Posts
                    .Where(e => e.AuthorId == _userId)
                    .Select(
                    e =>
                        new PostListItem
                        {
                            Id = e.Id,
                            Title = e.Title,                          
                        }
                     );
                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == id && e.AuthorId == _userId);
                return
                    new PostDetail
                    {
                        Id = entity.Id,
                        Title = entity.Title,
                        Text = entity.Text
                    };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == model.Id && e.AuthorId == _userId);

                entity.Title = model.Title;
                entity.Text = model.Text;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Posts
                        .Single(e => e.Id == id && e.AuthorId == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
        
    }
}
