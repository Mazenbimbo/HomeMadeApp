using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/user")]
public class UserController: ControllerBase
{
    List<User> users = new();

    [HttpGet]
    [Route("{ID}")]
    public IActionResult GetUser(int ID)
    {
        try
        {
            return Ok($"User with ID : {ID}");
        }
        catch(Exception e)
        {
            return Ok(e);
        }
        
    }

    [HttpGet]
    [Route("habit")]
    public IActionResult DoHabit(DoHabits habit)
    {
        return Ok(habit.pray);
    }

    [HttpPost]
    public IActionResult AddUser(User user)
    {
        users.Add(user);
        return Ok("Created Successfully!");
    }


}