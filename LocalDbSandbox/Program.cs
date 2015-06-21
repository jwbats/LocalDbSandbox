using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalDbSandbox
{
	class Program
	{

		private static void CreateNewBlogAndPosts()
		{
			using (BloggingContext context = new BloggingContext())
			{
				Post newPost1 = new Post()
				{
					Title   = "New Post 1" + Guid.NewGuid(),
					Content = "Post body 1." + Guid.NewGuid()
				};

				Post newPost2 = new Post()
				{
					Title   = "New Post 2" + Guid.NewGuid(),
					Content = "Post body 2." + Guid.NewGuid()
				};

				Blog newBlog = new Blog
				{
					Name  = "NewBlog" + Guid.NewGuid(),
					Url   = "http://newblog" + Guid.NewGuid() + ".com",
					Posts = new Post[] { newPost1, newPost2 }
				};
				
				context.Blogs.Add(newBlog);
				context.SaveChanges();			
			}
		}




		private static void OutputBlogs()
		{
			using (BloggingContext context = new BloggingContext())
			{
				Blog[] blogs = context.Blogs.OrderBy(x => x.Name).ToArray();

				foreach (Blog blog in blogs)
				{
					Console.WriteLine("=====");
					Console.WriteLine(blog.Name);
					Console.WriteLine("-----");

					foreach (Post post in blog.Posts)
					{
						Console.WriteLine(post.Title);
					}
					Console.WriteLine("=====");
					Console.WriteLine();
				}
			}
		}




		private static void Main(string[] args)
		{
			CreateNewBlogAndPosts();
			OutputBlogs();

			Console.WriteLine("Press any key to exit...");
			Console.ReadKey();
		}

	}
}
