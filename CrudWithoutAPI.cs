using System;
using System.Collections.Generic;
using System.Linq;

public class SiteLink
{
    public int Id { get; set; }
    public string SiteLinkName { get; set; }
    public int LinkTypeId { get; set; }
    public string LinkUrl { get; set; }
    public string LogonName { get; set; }
    public DateTime DateCreated { get; set; }
}

public class SiteLinkManager
{
    private List<SiteLink> siteLinks;
    private int nextId;

    public SiteLinkManager()
    {
        siteLinks = new List<SiteLink>();
        nextId = 1;
    }

    public void Create(SiteLink siteLink)
    {
        siteLink.Id = nextId++;
        siteLink.DateCreated = DateTime.Now;
        siteLinks.Add(siteLink);
    }

    public SiteLink Read(int id)
    {
        return siteLinks.FirstOrDefault(s => s.Id == id);
    }

    public void Update(int id, SiteLink updatedSiteLink)
    {
        SiteLink existingSiteLink = siteLinks.FirstOrDefault(s => s.Id == id);
        if (existingSiteLink != null)
        {
            existingSiteLink.SiteLinkName = updatedSiteLink.SiteLinkName;
            existingSiteLink.LinkTypeId = updatedSiteLink.LinkTypeId;
            existingSiteLink.LinkUrl = updatedSiteLink.LinkUrl;
            existingSiteLink.LogonName = updatedSiteLink.LogonName;
        }
    }

    public void Delete(int id)
    {
        SiteLink siteLinkRemove = siteLinks.FirstOrDefault(s => s.Id == id);
        if (siteLinkRemove != null)
        {
            siteLinks.Remove(siteLinkRemove);
        }
    }

    public List<SiteLink> GetAll()
    {
        return siteLinks;
    }
}


public class Program
{
    public static void Main()
    {
        SiteLinkManager manager = new SiteLinkManager();

        // Adding initial site links
        manager.Create(new SiteLink
        {
            SiteLinkName = "Google",
            LinkTypeId = 1,
            LinkUrl = "https://www.google.com",
            LogonName = "user1@example.com"
        });

        manager.Create(new SiteLink
        {
            SiteLinkName = "Microsoft",
            LinkTypeId = 2,
            LinkUrl = "https://www.microsoft.com",
            LogonName = "user2@example.com"
        });

        manager.Create(new SiteLink
        {
            SiteLinkName = "GitHub",
            LinkTypeId = 3,
            LinkUrl = "https://www.github.com",
            LogonName = "user3@example.com"
        });

        // Reading a site link
        SiteLink readSiteLink = manager.Read(2);
        Console.WriteLine("Read the sitelink:");
        Console.WriteLine(readSiteLink?.SiteLinkName);

        // Updating a site link
        SiteLink updateSiteLink = new SiteLink
        {
            SiteLinkName = "Updated GitHub",
            LinkTypeId = 3,
            LinkUrl = "https://www.updatedgithub.com",
            LogonName = "updateduser3@example.com"
        };
        manager.Update(3, updateSiteLink);
        readSiteLink = manager.Read(3);
        Console.WriteLine("Read the updated sitelink:");
        Console.WriteLine(readSiteLink?.SiteLinkName);

        // Deleting a site link
        manager.Delete(1);
        Console.WriteLine("Deleted site link with ID 1");

        List<SiteLink> allSiteLinks = manager.GetAll();
        Console.WriteLine("All site links:");
        foreach (var siteLink in allSiteLinks)
        {
            Console.WriteLine(siteLink?.SiteLinkName);
        }
    }
}
