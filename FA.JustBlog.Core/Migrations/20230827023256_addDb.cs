using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FA.JustBlog.Core.Migrations
{
    public partial class addDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    UrlSlug = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    PostContent = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlSlug = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Published = table.Column<bool>(type: "bit", nullable: false),
                    PostedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<bool>(type: "bit", nullable: false),
                    ViewCount = table.Column<int>(type: "int", nullable: false),
                    RateCount = table.Column<int>(type: "int", nullable: false),
                    TotalRate = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CommentHeader = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CommentText = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    CommentTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GalleryImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, defaultValueSql: "NEWID()"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1024)", maxLength: 1024, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GalleryImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GalleryImages_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostTagMaps",
                columns: table => new
                {
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TagId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTagMaps", x => new { x.PostId, x.TagId });
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTagMaps_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("5ebad110-f99c-44e2-ace4-8fee2c62ddaf"), "Articles related to sports", "Sports", "sports" },
                    { new Guid("9f401a3a-c1e6-4991-a178-13f46c8a234e"), "Articles related to food and cooking", "Food", "food" },
                    { new Guid("a0ba67f9-0466-46fa-92bf-46de2eb8b148"), "Articles related to technology", "Technology", "technology" },
                    { new Guid("f26f5873-7518-41cb-9c05-6cbc5d498158"), "Articles related to travel and tourism", "Travel", "travel" },
                    { new Guid("ffa825b4-4a4c-4e02-908c-6a1afd963a83"), "Articles related to science", "Science", "science" }
                });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Count", "Description", "Name", "UrlSlug" },
                values: new object[,]
                {
                    { new Guid("1aaafbb4-c1d8-4156-bea9-e4543037d496"), 1, "Articles related to science", "Science", "science" },
                    { new Guid("5846799f-32cd-46f1-af1d-4e6db4056fcc"), 2, "Articles related to travel and tourism", "Travel", "travel" },
                    { new Guid("6c3ebecd-611b-4b6d-830f-56eed85f46d8"), 2, "Articles related to programming", "Programming", "programming" },
                    { new Guid("8b2e3bc6-6690-4ca4-bd3a-ef815e10cf3f"), 4, "Articles related to food and cooking", "Food", "food" },
                    { new Guid("8f93c6f4-a209-4649-8202-1832a1ef916f"), 2, "Articles related to technology", "Technology", "technology" },
                    { new Guid("f00b8763-d419-485d-8e8b-9f2b1703f306"), 1, "Articles related to football", "Football", "football" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "CategoryId", "Modified", "PostContent", "PostedOn", "Published", "RateCount", "ShortDescription", "Title", "TotalRate", "UrlSlug", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("93b27486-9e08-43de-b995-6e9162270d3b"), new Guid("a0ba67f9-0466-46fa-92bf-46de2eb8b148"), false, "This article provides an in-depth overview of the C# programming language and its key features. C# is a modern, object-oriented programming language developed by Microsoft. It was designed to be simple, expressive, and versatile, making it an excellent choice for building a wide range of applications, from desktop software to web applications and even mobile apps.\r\n\r\nC# is part of the .NET framework, which provides a rich set of libraries and tools for developing robust and scalable applications. With C#, you can leverage the power of the .NET framework to create efficient and reliable software solutions.\r\n\r\nOne of the standout features of C# is its strong type system, which ensures type safety and helps catch errors at compile-time. This makes C# a reliable and secure language for building large-scale applications. Additionally, C# supports object-oriented programming concepts such as classes, inheritance, and polymorphism, allowing you to write clean and maintainable code.\r\n\r\nC# also includes powerful language features like LINQ (Language Integrated Query), which provides a unified way to query and manipulate data from various data sources, including databases, XML, and collections. LINQ simplifies data access and makes it easier to work with complex data structures.\r\n\r\nAnother notable feature of C# is its support for asynchronous programming with the async/await keywords. This enables you to write responsive and efficient code that can handle concurrent operations without blocking the main thread.\r\n\r\nIn addition to these core features, C# offers a wide range of libraries and frameworks for various domains, such as ASP.NET for web development, Xamarin for cross-platform mobile app development, and Unity for game development.\r\n\r\nWhether you're a beginner or an experienced developer, learning C# opens up a world of possibilities. It provides a solid foundation for building scalable and high-performance applications across different platforms. So, if you're ready to dive into the world of C# programming, let's get started!", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5402), true, 5, "A brief introduction to the C# programming language", "Introduction to C#", 20, "introduction-to-csharp", 100 },
                    { new Guid("a53997d5-131c-4c46-bd43-000470d81ea6"), new Guid("ffa825b4-4a4c-4e02-908c-6a1afd963a83"), false, "The field of web development is constantly evolving, with new technologies and trends emerging at a rapid pace. Staying updated with the latest web development trends is crucial for developers and businesses to deliver cutting-edge and user-friendly websites and web applications. In this article, we will explore some of the current trends shaping the world of web development.\r\n\r\nResponsive Web Design: With the increasing use of mobile devices, responsive web design has become a necessity. Websites that adapt seamlessly to different screen sizes and resolutions provide an optimal user experience across devices. Responsive design techniques, such as fluid grids, flexible images, and media queries, are essential for creating websites that are visually appealing and accessible on desktops, tablets, and smartphones.\r\n\r\nProgressive Web Apps (PWAs): PWAs combine the best features of web and mobile applications, providing users with an app-like experience directly through their web browsers. PWAs are fast, reliable, and can work offline, making them ideal for delivering engaging user experiences. They leverage modern web technologies, such as service workers and web app manifests, to enable features like push notifications, background syncing, and home screen installation.\r\n\r\nSingle-Page Applications (SPAs): SPAs have gained popularity due to their smooth and interactive user experiences. Unlike traditional multi-page websites, SPAs load content dynamically, updating only the necessary parts of the page. They utilize JavaScript frameworks like React, Angular, or Vue.js to build rich, responsive, and highly performant web applications. SPAs offer faster navigation, reduced server load, and enhanced user engagement.\r\n\r\nServerless Architecture: Serverless computing allows developers to focus on writing code without worrying about server management. In this architecture, the cloud provider takes care of infrastructure scaling and maintenance. Services like AWS Lambda and Azure Functions enable developers to build and deploy applications as small, independent functions. Serverless architectures offer improved scalability, reduced costs, and faster time to market.\r\n\r\nVoice User Interfaces (VUI): With the rise of voice assistants like Siri, Alexa, and Google Assistant, voice user interfaces have gained momentum. Integrating voice capabilities into websites and applications allows users to interact naturally using voice commands. Developers can leverage technologies like speech recognition and natural language processing to create voice-enabled experiences that enhance accessibility and user convenience.\r\n\r\nMotion and Microinteractions: Adding subtle animations, transitions, and microinteractions to web interfaces has become a popular trend. Motion design can guide users, provide visual feedback, and create engaging experiences. Well-implemented microinteractions, such as button hover effects or form validations, can significantly enhance usability and delight users.\r\n\r\nArtificial Intelligence (AI) and Machine Learning (ML): AI and ML technologies are making their way into web development, enabling intelligent features and personalized experiences. Chatbots, recommendation engines, and content generation based on user preferences are examples of AI-powered web applications. Developers can leverage frameworks like TensorFlow and libraries like scikit-learn to incorporate AI and ML capabilities into web projects.\r\n\r\nIt's important to note that while these trends are gaining traction, it's essential to evaluate their suitability for specific projects and consider factors such as target audience, project requirements, and scalability.\r\n\r\nIn conclusion, keeping up with the latest web development trends is crucial for staying competitive in the digital landscape. Embracing responsive design, PWAs, SPAs, serverless architecture, VUI, motion design, and AI/ML can help developers create modern, user-centric web experiences. By staying informed and continuously expanding their skill sets, web developers can deliver innovative and impactful solutions in the ever-evolving world of web development.", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5430), true, 2, "Stay updated with the latest web development trends", "Web Development Trends", 8, "web-development-trends", 50 },
                    { new Guid("c588b891-c728-4dca-968c-2416514fd4d7"), new Guid("5ebad110-f99c-44e2-ace4-8fee2c62ddaf"), false, "The Football World Cup, the most prestigious tournament in international football, captivated fans worldwide with its thrilling matches and unforgettable moments. Held every four years, the tournament showcases the best teams from around the globe competing for the coveted title.\r\n\r\nThe recent edition of the Football World Cup was no exception, delivering excitement, drama, and exceptional displays of skill. From the opening match to the final showdown, the tournament kept fans on the edge of their seats.\r\n\r\nThe journey began with the group stage, where teams battled fiercely to secure their spots in the knockout rounds. From stunning upsets to dominant performances, the group stage set the stage for the intense competition that lay ahead.\r\n\r\nAs the tournament progressed, there were several standout matches that will be etched in the memories of football enthusiasts. Thrilling comebacks, last-minute goals, and extraordinary individual performances added to the spectacle. Every match brought its share of unexpected twists and turns, showcasing the unpredictable nature of the beautiful game.\r\n\r\nThe knockout stage intensified the drama, with matches becoming even more competitive and high-stakes. As teams fought for survival, the pressure mounted, and the margin for error decreased. Penalty shootouts, extra time thrillers, and breathtaking goals kept fans enthralled until the very end.\r\n\r\nThe semifinals brought together the best of the best, where the remaining teams showcased their skills and determination. The battles on the pitch were fierce, and the stakes were incredibly high. The winners emerged, earning their place in the ultimate showdown.\r\n\r\nFinally, the grand finale arrived, showcasing the pinnacle of football excellence. The two best teams faced off, delivering a match filled with tension, passion, and pure sporting brilliance. The world watched in awe as the champions of the Football World Cup were crowned.\r\n\r\nBeyond the matches themselves, the tournament was also a celebration of the sport's unifying power. Fans from different nations came together to support their teams, creating an atmosphere of camaraderie and shared passion. The Football World Cup transcends borders, bringing people together through their love for the game.\r\n\r\nIn conclusion, the recent edition of the Football World Cup was a testament to the sheer excitement and global appeal of the sport. It provided unforgettable moments, showcased exceptional talent, and united fans from all corners of the world. As we eagerly await the next installment of this incredible tournament, the memories of this edition will forever remain etched in football history.", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5411), true, 2, "Recap of the recent Football World Cup", "Football World Cup", 8, "football-world-cup", 50 },
                    { new Guid("dd2d20eb-6300-4a73-9344-23d3e152bff1"), new Guid("f26f5873-7518-41cb-9c05-6cbc5d498158"), false, "Located in the Gulf of Tonkin, Ha Long Bay is a breathtaking destination that captivates travelers with its stunning natural beauty. As a UNESCO World Heritage Site, it boasts a unique landscape of emerald waters, towering limestone karsts, and picturesque islands, making it a must-visit location for any travel enthusiast. Ha Long Bay offers a plethora of activities and experiences that cater to diverse interests. One of the most popular ways to explore the bay is by taking a cruise. Hop aboard a traditional junk boat or a luxurious vessel and set sail through the calm waters, surrounded by the majestic karst formations. As you cruise along, you'll encounter hidden caves, pristine beaches, and floating fishing villages, providing an immersive glimpse into the local way of life. For nature lovers and adventure seekers, Ha Long Bay offers opportunities for kayaking, rock climbing, and hiking. Paddle through narrow waterways, marvel at the limestone cliffs up close, or ascend to the top of a karst for a panoramic view of the bay. The region's diverse flora and fauna, including rare species, add to the allure of its natural wonders. Ha Long Bay is also steeped in rich history and culture. Visit the ancient Thien Cung Cave, adorned with stalactites and stalagmites, and learn about the legends and myths associated with the cave. Engage with the friendly locals and discover their traditional fishing techniques and handicrafts, gaining insight into the region's heritage. Indulge in the delicious seafood cuisine that Ha Long Bay is renowned for. Freshly caught seafood, such as succulent prawns, clams, and fish, are expertly prepared and served in local restaurants and floating seafood markets. Immerse yourself in the flavors of the region, tantalizing your taste buds with the culinary delights of Ha Long Bay.", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5437), true, 2, "Embark on a mesmerizing journey to Ha Long Bay, a UNESCO World Heritage Site", "Travel to Ha Long Bay", 8, "travel-to-ha-long-bay", 100 },
                    { new Guid("ee0ecaf5-a63c-4817-9a42-bba704e19690"), new Guid("9f401a3a-c1e6-4991-a178-13f46c8a234e"), false, "Vietnamese cuisine is renowned worldwide for its vibrant flavors, fresh ingredients, and harmonious balance of textures. From street food stalls to upscale restaurants, the food scene in Vietnam is a culinary adventure that delights the senses and leaves a lasting impression on food lovers. One of the defining characteristics of Vietnamese cuisine is its emphasis on freshness. The use of aromatic herbs, crisp vegetables, and a variety of spices creates dishes that burst with flavor. The cuisine also showcases a harmonious blend of sweet, sour, salty, and spicy elements, creating a complex yet balanced taste profile. Pho, the iconic Vietnamese noodle soup, is a must-try dish. Made with a flavorful broth, rice noodles, and tender slices of beef or chicken, it is often garnished with fresh herbs, bean sprouts, and lime. The combination of savory broth, fragrant herbs, and tender meat makes pho a comforting and satisfying meal. Banh mi, a Vietnamese sandwich, is another popular street food that has gained international fame. It consists of a crusty baguette filled with a variety of fillings, such as grilled pork, pate, pickled vegetables, and herbs. The result is a mouthwatering combination of textures and flavors that creates a delightful culinary experience. Vietnamese cuisine is also known for its fresh spring rolls, called Goi Cuon. These translucent rice paper rolls are filled with a combination of fresh vegetables, herbs, rice noodles, and often shrimp or pork. They are typically served with a flavorful dipping sauce, adding an extra layer of taste to this refreshing and healthy dish.", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5446), true, 2, "Discover the vibrant and diverse culinary traditions of Vietnam", "Food in Vietnam", 8, "food-in-vietnam", 1000 },
                    { new Guid("fe6e3684-1d56-4c8d-a73c-7e515c880203"), new Guid("ffa825b4-4a4c-4e02-908c-6a1afd963a83"), false, "Programming is the art of instructing a computer to perform specific tasks. It is a skill that empowers individuals to create software, develop websites, automate processes, and solve complex problems. In this article, we will explore the fundamental concepts of programming and provide you with a solid foundation to embark on your programming journey.\r\n\r\nAt its core, programming involves writing a series of instructions, known as code, in a programming language that the computer can understand and execute. These instructions can range from simple calculations to intricate algorithms that manipulate data and perform complex operations.\r\n\r\nBefore diving into coding, it is essential to understand the basic building blocks of programming. Variables are used to store and manipulate data, such as numbers, text, and more. They act as containers that hold information and can be accessed and modified throughout the program.\r\n\r\nControl structures, such as conditionals and loops, allow programmers to control the flow of execution in a program. Conditionals, like if statements, enable the program to make decisions based on certain conditions. Loops, such as for and while loops, enable repetitive execution of a block of code until a specific condition is met.\r\n\r\nFunctions are reusable blocks of code that perform a specific task. They help in organizing code, promoting modularity, and reducing redundancy. By defining functions, programmers can break down complex problems into smaller, manageable tasks, making the code more readable and maintainable.\r\n\r\nData structures, such as arrays, lists, and dictionaries, allow programmers to store and organize collections of related data. These data structures provide efficient ways to access, manipulate, and iterate over groups of values.\r\n\r\nAlgorithms form the heart of programming. They are step-by-step procedures or recipes for solving specific problems. By designing efficient algorithms, programmers can optimize the performance of their programs and solve complex tasks with elegance and precision.\r\n\r\nProblem-solving is a crucial skill in programming. It involves breaking down a problem into smaller subproblems, understanding the requirements, and designing a solution using programming concepts and techniques. Strong problem-solving skills enable programmers to tackle challenges effectively and develop robust solutions.\r\n\r\nAs you embark on your programming journey, it is important to practice regularly and engage in hands-on projects. The best way to learn programming is by doing, experimenting, and building real-world applications. Online resources, tutorials, and coding communities can provide valuable guidance and support along the way.\r\n\r\nIn conclusion, programming is a powerful skill that allows you to bring your ideas to life, automate tasks, and solve problems creatively. By understanding the fundamental concepts of programming and continuously honing your skills, you will unlock endless possibilities in the digital world. So, roll up your sleeves, grab your favorite programming language, and embark on this exciting journey of learning and creation.", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5420), true, 5, "Learn the basics of programming", "Introduction to Programming", 20, "introduction-to-programming", 100 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "CommentHeader", "CommentText", "CommentTime", "Email", "Name", "PostId" },
                values: new object[,]
                {
                    { new Guid("2152c9d9-c5ff-42c5-b436-0e86c8c98ecb"), "Great article!", "I really enjoyed reading this. Thanks for sharing!", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5504), "john@example.com", "John", new Guid("93b27486-9e08-43de-b995-6e9162270d3b") },
                    { new Guid("3427c7a8-50a0-464c-a9b0-1a7013f9a3ca"), "Inspiring content", "The content of this post is truly inspiring. It motivated me to plan my next travel adventure!", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5590), "sarah@example.com", "Sarah", new Guid("ee0ecaf5-a63c-4817-9a42-bba704e19690") },
                    { new Guid("3bdb9f10-125d-4b9f-98f1-d3d6d25f3f4e"), "Helpful content", "This post was very helpful in understanding the subject. Thanks for sharing!", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5567), "david@example.com", "David", new Guid("fe6e3684-1d56-4c8d-a73c-7e515c880203") },
                    { new Guid("6d189bc8-2e1d-486c-bb92-abf911203de7"), "Great insights", "I learned a lot from this post. It provided great insights into the topic.", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5541), "emily@example.com", "Emily", new Guid("c588b891-c728-4dca-968c-2416514fd4d7") },
                    { new Guid("83419652-1f32-4719-81f4-cd8c40072c45"), "Well-explained", "The concepts explained in this post were clear and concise. Thank you!", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5535), "michael@example.com", "Michael", new Guid("93b27486-9e08-43de-b995-6e9162270d3b") },
                    { new Guid("93787122-9e4e-468c-8c21-95ad88c87efd"), "Informative post", "I found this post to be very informative. Thanks for sharing!", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5520), "alex@example.com", "Alex", new Guid("fe6e3684-1d56-4c8d-a73c-7e515c880203") },
                    { new Guid("c6f70c8d-e239-4863-be5f-eb069085c587"), "Informative post", "This post provided great insights. Thank you!", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5575), "emily@example.com", "Emily", new Guid("dd2d20eb-6300-4a73-9344-23d3e152bff1") },
                    { new Guid("d382966a-b154-4f11-aec4-581a7bc3be97"), "Excellent content!", "This article provided me with valuable insights. Well done!", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5513), "jane@example.com", "Jane", new Guid("c588b891-c728-4dca-968c-2416514fd4d7") },
                    { new Guid("d8834425-eef6-4be1-89df-27002594976c"), "Great examples", "The examples provided in this post were really helpful. Good job!", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5528), "sarah@example.com", "Sarah", new Guid("a53997d5-131c-4c46-bd43-000470d81ea6") },
                    { new Guid("f6b2988f-5a11-4c58-8b23-e29d47d83a8a"), "Well-written", "I found this post to be well-written and engaging. Nice job!", new DateTime(2023, 8, 27, 2, 32, 55, 436, DateTimeKind.Utc).AddTicks(5582), "michael@example.com", "Michael", new Guid("dd2d20eb-6300-4a73-9344-23d3e152bff1") }
                });

            migrationBuilder.InsertData(
                table: "GalleryImages",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "ImageUrl", "PostId", "Title" },
                values: new object[,]
                {
                    { new Guid("20dc3bb3-efd3-4ac7-99de-1d0f0769a1fa"), "Anh Quan", new DateTime(2023, 8, 27, 9, 32, 55, 436, DateTimeKind.Local).AddTicks(4878), "Learn basic", "~/assets/img/programming.jpg", new Guid("fe6e3684-1d56-4c8d-a73c-7e515c880203"), "Introduction to Programming" },
                    { new Guid("383a127b-edc7-4d23-acf4-11fd9f9829ca"), "Ta Van Toan", new DateTime(2023, 8, 27, 9, 32, 55, 436, DateTimeKind.Local).AddTicks(4896), "Supper WEB", "~/assets/img/Web-Development-Trends.jpg", new Guid("a53997d5-131c-4c46-bd43-000470d81ea6"), "WEB trending" },
                    { new Guid("9aacba2b-a716-4d12-9cef-fa01594b09ed"), "Tran Huy Tho", new DateTime(2023, 8, 27, 9, 32, 55, 436, DateTimeKind.Local).AddTicks(4926), "Supper likes", "~/assets/img/food_3.jpg", new Guid("ee0ecaf5-a63c-4817-9a42-bba704e19690"), "Food in Viet Nam" },
                    { new Guid("c2111533-a0ae-4d49-afcc-67bb72db3bbc"), "Pham Thi Len", new DateTime(2023, 8, 27, 9, 32, 55, 436, DateTimeKind.Local).AddTicks(4911), "Description for Image 1", "~/assets/img/Halong-Main-picture.jpg", new Guid("dd2d20eb-6300-4a73-9344-23d3e152bff1"), "Ha Long Bay" },
                    { new Guid("dcb51947-bbcb-4fd1-a907-234e7d139663"), "Fabrizio Romano", new DateTime(2023, 8, 27, 9, 32, 55, 436, DateTimeKind.Local).AddTicks(4870), "Messi Winner Football World Cup 2022", "~/assets/img/footballworlcup.jpg", new Guid("c588b891-c728-4dca-968c-2416514fd4d7"), "Football World Cup" },
                    { new Guid("f7098ae8-87ce-4d09-86c5-8ff1058edb56"), "Tran Van Hanh", new DateTime(2023, 8, 27, 9, 32, 55, 436, DateTimeKind.Local).AddTicks(4844), "Introduction programming C#", "~/assets/img/Introduction-to-C.jpg", new Guid("93b27486-9e08-43de-b995-6e9162270d3b"), "Learn C#" }
                });

            migrationBuilder.InsertData(
                table: "PostTagMaps",
                columns: new[] { "PostId", "TagId" },
                values: new object[,]
                {
                    { new Guid("93b27486-9e08-43de-b995-6e9162270d3b"), new Guid("6c3ebecd-611b-4b6d-830f-56eed85f46d8") },
                    { new Guid("93b27486-9e08-43de-b995-6e9162270d3b"), new Guid("8f93c6f4-a209-4649-8202-1832a1ef916f") },
                    { new Guid("a53997d5-131c-4c46-bd43-000470d81ea6"), new Guid("8f93c6f4-a209-4649-8202-1832a1ef916f") },
                    { new Guid("c588b891-c728-4dca-968c-2416514fd4d7"), new Guid("5846799f-32cd-46f1-af1d-4e6db4056fcc") },
                    { new Guid("c588b891-c728-4dca-968c-2416514fd4d7"), new Guid("f00b8763-d419-485d-8e8b-9f2b1703f306") },
                    { new Guid("dd2d20eb-6300-4a73-9344-23d3e152bff1"), new Guid("5846799f-32cd-46f1-af1d-4e6db4056fcc") },
                    { new Guid("ee0ecaf5-a63c-4817-9a42-bba704e19690"), new Guid("8b2e3bc6-6690-4ca4-bd3a-ef815e10cf3f") },
                    { new Guid("fe6e3684-1d56-4c8d-a73c-7e515c880203"), new Guid("6c3ebecd-611b-4b6d-830f-56eed85f46d8") },
                    { new Guid("fe6e3684-1d56-4c8d-a73c-7e515c880203"), new Guid("8f93c6f4-a209-4649-8202-1832a1ef916f") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_GalleryImages_PostId",
                table: "GalleryImages",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTagMaps_TagId",
                table: "PostTagMaps",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "GalleryImages");

            migrationBuilder.DropTable(
                name: "PostTagMaps");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
