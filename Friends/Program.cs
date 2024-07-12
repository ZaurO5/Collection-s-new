using System;
using System.Collections.Generic;
public class Program
{
    public static void Main()
    {
        SocialMedia socialMedia = new SocialMedia();
        socialMedia.AddFriend("Amina", "Ilkin");
        socialMedia.AddFriend("Amina", "Namiq");
        socialMedia.AddFriend("Ilkin", "Amina");

        Console.WriteLine("All friends of Amina:");
        foreach (var friend in socialMedia.GetAllFriendsByUsername("Amina"))
        {
            Console.WriteLine(friend);
        }

        socialMedia.RemoveFriend("Amina", "Namiq");

        Console.WriteLine("All friends of Alice after removing Namiq:");
        foreach (var friend in socialMedia.GetAllFriendsByUsername("Amina"))
        {
            Console.WriteLine(friend);
        }
    }
}
