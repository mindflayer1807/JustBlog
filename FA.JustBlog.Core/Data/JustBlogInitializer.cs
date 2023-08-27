using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core
{
    public static class JustBlogInitializer
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            Guid imageId1 = Guid.NewGuid();
            Guid imageId2 = Guid.NewGuid();
            Guid imageId3 = Guid.NewGuid();
            Guid imageId4 = Guid.NewGuid();
            Guid imageId5 = Guid.NewGuid();
            Guid imageId6 = Guid.NewGuid();

            Guid tagId1 = Guid.NewGuid();
            Guid tagId2 = Guid.NewGuid();
            Guid tagId3 = Guid.NewGuid();
            Guid tagId4 = Guid.NewGuid();
            Guid tagId5 = Guid.NewGuid();
            Guid tagId6 = Guid.NewGuid();

            Guid postId1 = Guid.NewGuid();
            Guid postId2 = Guid.NewGuid();
            Guid postId3 = Guid.NewGuid();
            Guid postId4 = Guid.NewGuid();
            Guid postId5 = Guid.NewGuid();
            Guid postId6 = Guid.NewGuid();

            Guid categoryId1 = Guid.NewGuid();
            Guid categoryId2 = Guid.NewGuid();
            Guid categoryId3 = Guid.NewGuid();
            Guid categoryId4 = Guid.NewGuid();
            Guid categoryId5 = Guid.NewGuid();

            Guid commentId1 = Guid.NewGuid();
            Guid commentId2 = Guid.NewGuid();
            Guid commentId3 = Guid.NewGuid();
            Guid commentId4 = Guid.NewGuid();
            Guid commentId5 = Guid.NewGuid();
            Guid commentId6 = Guid.NewGuid();
            Guid commentId7 = Guid.NewGuid();
            Guid commentId8 = Guid.NewGuid();
            Guid commentId9 = Guid.NewGuid();
            Guid commentId10 = Guid.NewGuid();

            modelBuilder.Entity<GalleryImage>().HasData(
                new GalleryImage
                {
                    Id = Guid.Parse(imageId1.ToString()),
                    Title = "Learn C#",
                    Description = "Introduction programming C#",
                    ImageUrl = "~/assets/img/Introduction-to-C.jpg",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Tran Van Hanh",
                    PostId = Guid.Parse(postId1.ToString())
                },
                new GalleryImage
                {
                    Id = Guid.Parse(imageId2.ToString()),
                    Title = "Football World Cup",
                    Description = "Messi Winner Football World Cup 2022",
                    ImageUrl = "~/assets/img/footballworlcup.jpg",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Fabrizio Romano",
                    PostId = Guid.Parse(postId2.ToString())
                },
                new GalleryImage
                {
                    Id = Guid.Parse(imageId3.ToString()),
                    Title = "Introduction to Programming",
                    Description = "Learn basic",
                    ImageUrl = "~/assets/img/programming.jpg",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Anh Quan",
                    PostId = Guid.Parse(postId3.ToString())
                },
                new GalleryImage
                {
                    Id = Guid.Parse(imageId4.ToString()),
                    Title = "WEB trending",
                    Description = "Supper WEB",
                    ImageUrl = "~/assets/img/Web-Development-Trends.jpg",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Ta Van Toan",
                    PostId = Guid.Parse(postId4.ToString())
                },
                new GalleryImage
                {
                    Id = Guid.Parse(imageId5.ToString()),
                    Title = "Ha Long Bay",
                    Description = "Description for Image 1",
                    ImageUrl = "~/assets/img/Halong-Main-picture.jpg",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Pham Thi Len",
                    PostId = Guid.Parse(postId5.ToString())
                },
                new GalleryImage
                {
                    Id = Guid.Parse(imageId6.ToString()),
                    Title = "Food in Viet Nam",
                    Description = "Supper likes",
                    ImageUrl = "~/assets/img/food_3.jpg",
                    CreatedDate = DateTime.Now,
                    CreatedBy = "Tran Huy Tho",
                    PostId = Guid.Parse(postId6.ToString())
                }
            );

            modelBuilder.Entity<Tag>().HasData(
                new Tag
                {
                    Id = Guid.Parse(tagId1.ToString()),
                    Name = "Programming",
                    UrlSlug = "programming",
                    Description = "Articles related to programming",
                    Count = 2,
                },
                new Tag
                {
                    Id = Guid.Parse(tagId2.ToString()),
                    Name = "Football",
                    UrlSlug = "football",
                    Description = "Articles related to football",
                    Count = 1,
                },
                new Tag
                {
                    Id = Guid.Parse(tagId3.ToString()),
                    Name = "Technology",
                    UrlSlug = "technology",
                    Description = "Articles related to technology",
                    Count = 2,
                },
                new Tag
                {
                    Id = Guid.Parse(tagId4.ToString()),
                    Name = "Science",
                    UrlSlug = "science",
                    Description = "Articles related to science",
                    Count = 1,
                },
                new Tag
                {
                    Id = Guid.Parse(tagId5.ToString()),
                    Name = "Travel",
                    UrlSlug = "travel",
                    Description = "Articles related to travel and tourism",
                    Count = 2,
                },
                new Tag
                {
                    Id = Guid.Parse(tagId6.ToString()),
                    Name = "Food",
                    UrlSlug = "food",
                    Description = "Articles related to food and cooking",
                    Count = 4,
                }
            );


            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = Guid.Parse(categoryId1.ToString()),
                    Name = "Technology",
                    UrlSlug = "technology",
                    Description = "Articles related to technology",
                },
                new Category
                {
                    Id = Guid.Parse(categoryId2.ToString()),
                    Name = "Sports",
                    UrlSlug = "sports",
                    Description = "Articles related to sports",
                },
                new Category
                {
                    Id = Guid.Parse(categoryId3.ToString()),
                    Name = "Science",
                    UrlSlug = "science",
                    Description = "Articles related to science",
                },
                new Category
                {
                    Id = Guid.Parse(categoryId4.ToString()),
                    Name = "Travel",
                    UrlSlug = "travel",
                    Description = "Articles related to travel and tourism",
                },
                new Category
                {
                    Id = Guid.Parse(categoryId5.ToString()),
                    Name = "Food",
                    UrlSlug = "food",
                    Description = "Articles related to food and cooking",
                }
            );


            modelBuilder.Entity<Post>().HasData(
                new Post
                {
                    Id = Guid.Parse(postId1.ToString()),
                    Title = "Introduction to C#",
                    ShortDescription = "A brief introduction to the C# programming language",
                    PostContent = "This article provides an in-depth overview of the C# programming language and its key features. C# is a modern, object-oriented programming language developed by Microsoft. It was designed to be simple, expressive, and versatile, making it an excellent choice for building a wide range of applications, from desktop software to web applications and even mobile apps.\r\n\r\nC# is part of the .NET framework, which provides a rich set of libraries and tools for developing robust and scalable applications. With C#, you can leverage the power of the .NET framework to create efficient and reliable software solutions.\r\n\r\nOne of the standout features of C# is its strong type system, which ensures type safety and helps catch errors at compile-time. This makes C# a reliable and secure language for building large-scale applications. Additionally, C# supports object-oriented programming concepts such as classes, inheritance, and polymorphism, allowing you to write clean and maintainable code.\r\n\r\nC# also includes powerful language features like LINQ (Language Integrated Query), which provides a unified way to query and manipulate data from various data sources, including databases, XML, and collections. LINQ simplifies data access and makes it easier to work with complex data structures.\r\n\r\nAnother notable feature of C# is its support for asynchronous programming with the async/await keywords. This enables you to write responsive and efficient code that can handle concurrent operations without blocking the main thread.\r\n\r\nIn addition to these core features, C# offers a wide range of libraries and frameworks for various domains, such as ASP.NET for web development, Xamarin for cross-platform mobile app development, and Unity for game development.\r\n\r\nWhether you're a beginner or an experienced developer, learning C# opens up a world of possibilities. It provides a solid foundation for building scalable and high-performance applications across different platforms. So, if you're ready to dive into the world of C# programming, let's get started!",
                    UrlSlug = "introduction-to-csharp",
                    Published = true,
                    PostedOn = DateTime.UtcNow,
                    Modified = false,
                    ViewCount = 100,
                    RateCount = 5,
                    TotalRate = 20,
                    CategoryId = Guid.Parse(categoryId1.ToString()),
                },
                new Post
                {
                    Id = Guid.Parse(postId2.ToString()),
                    Title = "Football World Cup",
                    ShortDescription = "Recap of the recent Football World Cup",
                    PostContent = "The Football World Cup, the most prestigious tournament in international football, captivated fans worldwide with its thrilling matches and unforgettable moments. Held every four years, the tournament showcases the best teams from around the globe competing for the coveted title.\r\n\r\nThe recent edition of the Football World Cup was no exception, delivering excitement, drama, and exceptional displays of skill. From the opening match to the final showdown, the tournament kept fans on the edge of their seats.\r\n\r\nThe journey began with the group stage, where teams battled fiercely to secure their spots in the knockout rounds. From stunning upsets to dominant performances, the group stage set the stage for the intense competition that lay ahead.\r\n\r\nAs the tournament progressed, there were several standout matches that will be etched in the memories of football enthusiasts. Thrilling comebacks, last-minute goals, and extraordinary individual performances added to the spectacle. Every match brought its share of unexpected twists and turns, showcasing the unpredictable nature of the beautiful game.\r\n\r\nThe knockout stage intensified the drama, with matches becoming even more competitive and high-stakes. As teams fought for survival, the pressure mounted, and the margin for error decreased. Penalty shootouts, extra time thrillers, and breathtaking goals kept fans enthralled until the very end.\r\n\r\nThe semifinals brought together the best of the best, where the remaining teams showcased their skills and determination. The battles on the pitch were fierce, and the stakes were incredibly high. The winners emerged, earning their place in the ultimate showdown.\r\n\r\nFinally, the grand finale arrived, showcasing the pinnacle of football excellence. The two best teams faced off, delivering a match filled with tension, passion, and pure sporting brilliance. The world watched in awe as the champions of the Football World Cup were crowned.\r\n\r\nBeyond the matches themselves, the tournament was also a celebration of the sport's unifying power. Fans from different nations came together to support their teams, creating an atmosphere of camaraderie and shared passion. The Football World Cup transcends borders, bringing people together through their love for the game.\r\n\r\nIn conclusion, the recent edition of the Football World Cup was a testament to the sheer excitement and global appeal of the sport. It provided unforgettable moments, showcased exceptional talent, and united fans from all corners of the world. As we eagerly await the next installment of this incredible tournament, the memories of this edition will forever remain etched in football history.",
                    UrlSlug = "football-world-cup",
                    Published = true,
                    PostedOn = DateTime.UtcNow,
                    Modified = false,
                    ViewCount = 50,
                    RateCount = 2,
                    TotalRate = 8,
                    CategoryId = Guid.Parse(categoryId2.ToString()),
                },
                new Post
                {
                    Id = Guid.Parse(postId3.ToString()),
                    Title = "Introduction to Programming",
                    ShortDescription = "Learn the basics of programming",
                    PostContent = "Programming is the art of instructing a computer to perform specific tasks. It is a skill that empowers individuals to create software, develop websites, automate processes, and solve complex problems. In this article, we will explore the fundamental concepts of programming and provide you with a solid foundation to embark on your programming journey.\r\n\r\nAt its core, programming involves writing a series of instructions, known as code, in a programming language that the computer can understand and execute. These instructions can range from simple calculations to intricate algorithms that manipulate data and perform complex operations.\r\n\r\nBefore diving into coding, it is essential to understand the basic building blocks of programming. Variables are used to store and manipulate data, such as numbers, text, and more. They act as containers that hold information and can be accessed and modified throughout the program.\r\n\r\nControl structures, such as conditionals and loops, allow programmers to control the flow of execution in a program. Conditionals, like if statements, enable the program to make decisions based on certain conditions. Loops, such as for and while loops, enable repetitive execution of a block of code until a specific condition is met.\r\n\r\nFunctions are reusable blocks of code that perform a specific task. They help in organizing code, promoting modularity, and reducing redundancy. By defining functions, programmers can break down complex problems into smaller, manageable tasks, making the code more readable and maintainable.\r\n\r\nData structures, such as arrays, lists, and dictionaries, allow programmers to store and organize collections of related data. These data structures provide efficient ways to access, manipulate, and iterate over groups of values.\r\n\r\nAlgorithms form the heart of programming. They are step-by-step procedures or recipes for solving specific problems. By designing efficient algorithms, programmers can optimize the performance of their programs and solve complex tasks with elegance and precision.\r\n\r\nProblem-solving is a crucial skill in programming. It involves breaking down a problem into smaller subproblems, understanding the requirements, and designing a solution using programming concepts and techniques. Strong problem-solving skills enable programmers to tackle challenges effectively and develop robust solutions.\r\n\r\nAs you embark on your programming journey, it is important to practice regularly and engage in hands-on projects. The best way to learn programming is by doing, experimenting, and building real-world applications. Online resources, tutorials, and coding communities can provide valuable guidance and support along the way.\r\n\r\nIn conclusion, programming is a powerful skill that allows you to bring your ideas to life, automate tasks, and solve problems creatively. By understanding the fundamental concepts of programming and continuously honing your skills, you will unlock endless possibilities in the digital world. So, roll up your sleeves, grab your favorite programming language, and embark on this exciting journey of learning and creation.",
                    UrlSlug = "introduction-to-programming",
                    Published = true,
                    PostedOn = DateTime.UtcNow,
                    Modified = false,
                    ViewCount = 100,
                    RateCount = 5,
                    TotalRate = 20,
                    CategoryId = Guid.Parse(categoryId3.ToString()),
                },
                new Post
                {
                    Id = Guid.Parse(postId4.ToString()),
                    Title = "Web Development Trends",
                    ShortDescription = "Stay updated with the latest web development trends",
                    PostContent = "The field of web development is constantly evolving, with new technologies and trends emerging at a rapid pace. Staying updated with the latest web development trends is crucial for developers and businesses to deliver cutting-edge and user-friendly websites and web applications. In this article, we will explore some of the current trends shaping the world of web development.\r\n\r\nResponsive Web Design: With the increasing use of mobile devices, responsive web design has become a necessity. Websites that adapt seamlessly to different screen sizes and resolutions provide an optimal user experience across devices. Responsive design techniques, such as fluid grids, flexible images, and media queries, are essential for creating websites that are visually appealing and accessible on desktops, tablets, and smartphones.\r\n\r\nProgressive Web Apps (PWAs): PWAs combine the best features of web and mobile applications, providing users with an app-like experience directly through their web browsers. PWAs are fast, reliable, and can work offline, making them ideal for delivering engaging user experiences. They leverage modern web technologies, such as service workers and web app manifests, to enable features like push notifications, background syncing, and home screen installation.\r\n\r\nSingle-Page Applications (SPAs): SPAs have gained popularity due to their smooth and interactive user experiences. Unlike traditional multi-page websites, SPAs load content dynamically, updating only the necessary parts of the page. They utilize JavaScript frameworks like React, Angular, or Vue.js to build rich, responsive, and highly performant web applications. SPAs offer faster navigation, reduced server load, and enhanced user engagement.\r\n\r\nServerless Architecture: Serverless computing allows developers to focus on writing code without worrying about server management. In this architecture, the cloud provider takes care of infrastructure scaling and maintenance. Services like AWS Lambda and Azure Functions enable developers to build and deploy applications as small, independent functions. Serverless architectures offer improved scalability, reduced costs, and faster time to market.\r\n\r\nVoice User Interfaces (VUI): With the rise of voice assistants like Siri, Alexa, and Google Assistant, voice user interfaces have gained momentum. Integrating voice capabilities into websites and applications allows users to interact naturally using voice commands. Developers can leverage technologies like speech recognition and natural language processing to create voice-enabled experiences that enhance accessibility and user convenience.\r\n\r\nMotion and Microinteractions: Adding subtle animations, transitions, and microinteractions to web interfaces has become a popular trend. Motion design can guide users, provide visual feedback, and create engaging experiences. Well-implemented microinteractions, such as button hover effects or form validations, can significantly enhance usability and delight users.\r\n\r\nArtificial Intelligence (AI) and Machine Learning (ML): AI and ML technologies are making their way into web development, enabling intelligent features and personalized experiences. Chatbots, recommendation engines, and content generation based on user preferences are examples of AI-powered web applications. Developers can leverage frameworks like TensorFlow and libraries like scikit-learn to incorporate AI and ML capabilities into web projects.\r\n\r\nIt's important to note that while these trends are gaining traction, it's essential to evaluate their suitability for specific projects and consider factors such as target audience, project requirements, and scalability.\r\n\r\nIn conclusion, keeping up with the latest web development trends is crucial for staying competitive in the digital landscape. Embracing responsive design, PWAs, SPAs, serverless architecture, VUI, motion design, and AI/ML can help developers create modern, user-centric web experiences. By staying informed and continuously expanding their skill sets, web developers can deliver innovative and impactful solutions in the ever-evolving world of web development.",
                    UrlSlug = "web-development-trends",
                    Published = true,
                    PostedOn = DateTime.UtcNow,
                    Modified = false,
                    ViewCount = 50,
                    RateCount = 2,
                    TotalRate = 8,
                    CategoryId = Guid.Parse(categoryId3.ToString()),
                },

                new Post
                {
                    Id = Guid.Parse(postId5.ToString()),
                    Title = "Travel to Ha Long Bay",
                    ShortDescription = "Embark on a mesmerizing journey to Ha Long Bay, a UNESCO World Heritage Site",
                    PostContent = "Located in the Gulf of Tonkin, Ha Long Bay is a breathtaking destination that captivates travelers with its stunning natural beauty. As a UNESCO World Heritage Site, it boasts a unique landscape of emerald waters, towering limestone karsts, and picturesque islands, making it a must-visit location for any travel enthusiast. Ha Long Bay offers a plethora of activities and experiences that cater to diverse interests. One of the most popular ways to explore the bay is by taking a cruise. Hop aboard a traditional junk boat or a luxurious vessel and set sail through the calm waters, surrounded by the majestic karst formations. As you cruise along, you'll encounter hidden caves, pristine beaches, and floating fishing villages, providing an immersive glimpse into the local way of life. For nature lovers and adventure seekers, Ha Long Bay offers opportunities for kayaking, rock climbing, and hiking. Paddle through narrow waterways, marvel at the limestone cliffs up close, or ascend to the top of a karst for a panoramic view of the bay. The region's diverse flora and fauna, including rare species, add to the allure of its natural wonders. Ha Long Bay is also steeped in rich history and culture. Visit the ancient Thien Cung Cave, adorned with stalactites and stalagmites, and learn about the legends and myths associated with the cave. Engage with the friendly locals and discover their traditional fishing techniques and handicrafts, gaining insight into the region's heritage. Indulge in the delicious seafood cuisine that Ha Long Bay is renowned for. Freshly caught seafood, such as succulent prawns, clams, and fish, are expertly prepared and served in local restaurants and floating seafood markets. Immerse yourself in the flavors of the region, tantalizing your taste buds with the culinary delights of Ha Long Bay.",
                    UrlSlug = "travel-to-ha-long-bay",
                    Published = true,
                    PostedOn = DateTime.UtcNow,
                    Modified = false,
                    ViewCount = 100,
                    RateCount = 2,
                    TotalRate = 8,
                    CategoryId = Guid.Parse(categoryId4.ToString()),
                },

                new Post
                {
                    Id = Guid.Parse(postId6.ToString()),
                    Title = "Food in Vietnam",
                    ShortDescription = "Discover the vibrant and diverse culinary traditions of Vietnam",
                    PostContent = "Vietnamese cuisine is renowned worldwide for its vibrant flavors, fresh ingredients, and harmonious balance of textures. From street food stalls to upscale restaurants, the food scene in Vietnam is a culinary adventure that delights the senses and leaves a lasting impression on food lovers. One of the defining characteristics of Vietnamese cuisine is its emphasis on freshness. The use of aromatic herbs, crisp vegetables, and a variety of spices creates dishes that burst with flavor. The cuisine also showcases a harmonious blend of sweet, sour, salty, and spicy elements, creating a complex yet balanced taste profile. Pho, the iconic Vietnamese noodle soup, is a must-try dish. Made with a flavorful broth, rice noodles, and tender slices of beef or chicken, it is often garnished with fresh herbs, bean sprouts, and lime. The combination of savory broth, fragrant herbs, and tender meat makes pho a comforting and satisfying meal. Banh mi, a Vietnamese sandwich, is another popular street food that has gained international fame. It consists of a crusty baguette filled with a variety of fillings, such as grilled pork, pate, pickled vegetables, and herbs. The result is a mouthwatering combination of textures and flavors that creates a delightful culinary experience. Vietnamese cuisine is also known for its fresh spring rolls, called Goi Cuon. These translucent rice paper rolls are filled with a combination of fresh vegetables, herbs, rice noodles, and often shrimp or pork. They are typically served with a flavorful dipping sauce, adding an extra layer of taste to this refreshing and healthy dish.",
                    UrlSlug = "food-in-vietnam",
                    Published = true,
                    PostedOn = DateTime.UtcNow,
                    Modified = false,
                    ViewCount = 1000,
                    RateCount = 2,
                    TotalRate = 8,
                    CategoryId = Guid.Parse(categoryId5.ToString()),
                }
            );


            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = Guid.Parse(commentId1.ToString()),
                    Name = "John",
                    Email = "john@example.com",
                    PostId = Guid.Parse(postId1.ToString()),
                    CommentHeader = "Great article!",
                    CommentText = "I really enjoyed reading this. Thanks for sharing!",
                    CommentTime = DateTime.UtcNow,
                },
                new Comment
                {
                    Id = Guid.Parse(commentId2.ToString()),
                    Name = "Jane",
                    Email = "jane@example.com",
                    PostId = Guid.Parse(postId2.ToString()),
                    CommentHeader = "Excellent content!",
                    CommentText = "This article provided me with valuable insights. Well done!",
                    CommentTime = DateTime.UtcNow,
                },
                new Comment
                {
                    Id = Guid.Parse(commentId3.ToString()),
                    Name = "Alex",
                    Email = "alex@example.com",
                    PostId = Guid.Parse(postId3.ToString()),
                    CommentHeader = "Informative post",
                    CommentText = "I found this post to be very informative. Thanks for sharing!",
                    CommentTime = DateTime.UtcNow,
                },
                new Comment
                {
                    Id = Guid.Parse(commentId4.ToString()),
                    Name = "Sarah",
                    Email = "sarah@example.com",
                    PostId = Guid.Parse(postId4.ToString()),
                    CommentHeader = "Great examples",
                    CommentText = "The examples provided in this post were really helpful. Good job!",
                    CommentTime = DateTime.UtcNow,
                },
                new Comment
                {
                    Id = Guid.Parse(commentId5.ToString()),
                    Name = "Michael",
                    Email = "michael@example.com",
                    PostId = Guid.Parse(postId1.ToString()),
                    CommentHeader = "Well-explained",
                    CommentText = "The concepts explained in this post were clear and concise. Thank you!",
                    CommentTime = DateTime.UtcNow,
                },
                new Comment
                {
                    Id = Guid.Parse(commentId6.ToString()),
                    Name = "Emily",
                    Email = "emily@example.com",
                    PostId = Guid.Parse(postId2.ToString()),
                    CommentHeader = "Great insights",
                    CommentText = "I learned a lot from this post. It provided great insights into the topic.",
                    CommentTime = DateTime.UtcNow,
                },
                new Comment
                {
                    Id = Guid.Parse(commentId7.ToString()),
                    Name = "David",
                    Email = "david@example.com",
                    PostId = Guid.Parse(postId3.ToString()),
                    CommentHeader = "Helpful content",
                    CommentText = "This post was very helpful in understanding the subject. Thanks for sharing!",
                    CommentTime = DateTime.UtcNow,
                },
                new Comment
                {
                    Id = Guid.Parse(commentId8.ToString()),
                    Name = "Emily",
                    Email = "emily@example.com",
                    PostId = Guid.Parse(postId5.ToString()),
                    CommentHeader = "Informative post",
                    CommentText = "This post provided great insights. Thank you!",
                    CommentTime = DateTime.UtcNow,
                },
                new Comment
                {
                    Id = Guid.Parse(commentId9.ToString()),
                    Name = "Michael",
                    Email = "michael@example.com",
                    PostId = Guid.Parse(postId5.ToString()),
                    CommentHeader = "Well-written",
                    CommentText = "I found this post to be well-written and engaging. Nice job!",
                    CommentTime = DateTime.UtcNow,
                },
                new Comment
                {
                    Id = Guid.Parse(commentId10.ToString()),
                    Name = "Sarah",
                    Email = "sarah@example.com",
                    PostId = Guid.Parse(postId6.ToString()),
                    CommentHeader = "Inspiring content",
                    CommentText = "The content of this post is truly inspiring. It motivated me to plan my next travel adventure!",
                    CommentTime = DateTime.UtcNow,
                }
            );

            modelBuilder.Entity<PostTagMap>().HasData(
                new
                {
                    PostId = Guid.Parse(postId1.ToString()),
                    TagId = Guid.Parse(tagId1.ToString())
                },
                new
                {
                    PostId = Guid.Parse(postId1.ToString()),
                    TagId = Guid.Parse(tagId3.ToString())
                },
                new
                {
                    PostId = Guid.Parse(postId2.ToString()),
                    TagId = Guid.Parse(tagId2.ToString())
                },
                new
                {
                    PostId = Guid.Parse(postId2.ToString()),
                    TagId = Guid.Parse(tagId5.ToString())
                },
                new
                {
                    PostId = Guid.Parse(postId3.ToString()),
                    TagId = Guid.Parse(tagId1.ToString())
                },
                new
                {
                    PostId = Guid.Parse(postId3.ToString()),
                    TagId = Guid.Parse(tagId3.ToString())
                },
                new
                {
                    PostId = Guid.Parse(postId4.ToString()),
                    TagId = Guid.Parse(tagId3.ToString())
                },
                new
                {
                    PostId = Guid.Parse(postId5.ToString()),
                    TagId = Guid.Parse(tagId5.ToString())
                },
                new
                {
                    PostId = Guid.Parse(postId6.ToString()),
                    TagId = Guid.Parse(tagId6.ToString())
                }
            );
        }
    }
}