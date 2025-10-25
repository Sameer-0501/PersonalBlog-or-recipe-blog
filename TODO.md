# TODO: Separate Home/Blog Pages and Implement Authentication

## 1. Separate Home and Blog Pages
- [x] Modify Client/Pages/Index.razor: Remove "/posts" route, add hero section with welcome text, quotes, and background image
- [x] Create new Client/Pages/Blog.razor page with PostsList component
- [x] Update Client/share/NavMenu.razor to link to "blog" instead of "posts"
- [x] Update Client/Pages/CreateEditPost.razor routes to use "blog" prefix
- [x] Update Client/Pages/PostDetails.razor routes to use "blog" prefix
- [x] Update Client/Pages/PostsList.razor navigation to use "blog" prefix

## 2. Implement Authentication
- [ ] Add ASP.NET Core Identity packages to Server/Server.csproj
- [ ] Configure Identity in Server/Program.cs with roles (User, Owner)
- [ ] Create Shared/Models/User.cs and Role.cs models
- [ ] Update Server/Data/AppDbContext.cs to inherit from IdentityDbContext
- [ ] Create Client/Pages/Login.razor page
- [ ] Create Client/Pages/Logout.razor page
- [ ] Update Client/Program.cs for authentication setup
- [ ] Protect create/edit/delete actions in PostsController for Owners
- [ ] Protect view actions for authenticated Users
- [ ] Update Client/share/NavMenu.razor to show login/logout based on auth state

## 3. Update CSS
- [x] Add hero section styles with background image to Client/wwwroot/css/app.css

## 4. Followup Steps
- [ ] Install Identity packages and run migrations
- [ ] Test routing and auth flows
