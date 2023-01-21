using Posts.Models;

namespace Posts.Logic
{
    public class PostManager
    {
        public PostManager AddPost(PostModel postModel)
        {
            using (var context = new PostContext())
            {
                context.Posts.Add(postModel);
                context.SaveChanges();
            }

            return this;
        }

        public PostManager RemovePost(int id)
        {
            using (var context = new PostContext())
            {
                var post = context.Posts.SingleOrDefault(x => x.ID == id);
                context.Posts.Remove(post);
                context.SaveChanges();
            }

            return this;
        }

        public PostManager UpdatePost(PostModel postModel)
        {
            using (var context = new PostContext())
            {
                context.Posts.Update(postModel);
                context.SaveChanges();
            }
            return this;
        }

        public PostManager ChangeTitle(int id, string newTitle)
        {
            using (var context = new PostContext())
            {
                var post = context.Posts.Single(x => x.ID == id);
                if (string.IsNullOrEmpty(newTitle))
                {
                    newTitle = "Brak tytułu";
                }
                post.Title = newTitle;
                this.UpdatePost(post);
            }
            return this;
        }

        public PostModel GetPost(int id)
        {
            using (var context = new PostContext())
            {
                var post = context.Posts.Single(x => x.ID == id);
                return post;
            }
        }


        public List<PostModel> GetPosts()
        {
            using (var context = new PostContext())
            {
                var posts = context.Posts.ToList();

                return posts;
            }
        }

            
    }
}
