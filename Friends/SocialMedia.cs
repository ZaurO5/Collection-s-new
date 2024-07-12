using System;
using System.Collections.Generic;
public class SocialMedia
{
    public Dictionary<string, List<string>> Friends { get; private set; }

    public SocialMedia()
    {
        Friends = new Dictionary<string, List<string>>();
    }

    public void AddFriend(string username, string friendName)
    {
        if (!Friends.ContainsKey(username))
        {
            Friends[username] = new List<string>();
        }

        if (!Friends[username].Contains(friendName))
        {
            Friends[username].Add(friendName);
            Console.WriteLine($"Friend {friendName} added to user {username}.");
        }
        else
        {
            Console.WriteLine($"{friendName} is already a friend of {username}.");
        }
    }

    public void RemoveFriend(string username, string friendName)
    {
        if (Friends.ContainsKey(username) && Friends[username].Contains(friendName))
        {
            Friends[username].Remove(friendName);
            Console.WriteLine($"Friend {friendName} removed from user {username}.");
        }
        else
        {
            Console.WriteLine($"{friendName} is not a friend of {username}.");
        }
    }

    public List<string> GetAllFriendsByUsername(string username)
    {
        if (Friends.ContainsKey(username))
        {
            return Friends[username];
        }
        else
        {
            Console.WriteLine($"User {username} not found.");
            return new List<string>();
        }
    }
}

