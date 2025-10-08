Ensure Node Js, git and .net9 sdk is install

clone project git clone https://github.com/MuntasirHasan2/BlogPostManager.git

open Terminal on cloned Repo
Run client

cd BlogPostManager.Client
npm i
npm run dev


open new terminal
cd BlogPostManager.Server
dotnet restore
dotnet ef database update
dotnet run

You can also you postman for a better verification of the backend since with limited time some connection couldn't be made, example of
post request to crearte user:
url: http://localhost:5154/user

body:
{
  "userName": "newuser",
  "email": "newuser@example.com",
  "password": "Password"
}
<img width="1470" height="956" alt="Screenshot 2025-10-08 at 10 52 39" src="https://github.com/user-attachments/assets/17ee2b77-873a-48da-b0e2-c0b56961abd3" />


a token will be returned

