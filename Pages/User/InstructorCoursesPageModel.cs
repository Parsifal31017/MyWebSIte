using MyWebSite.Data;
using MyWebSite.Models;
using MyWebSite.Models.CompanyViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MyWebSite.Pages.User
{
    public class InstructorCoursesPageModel : PageModel
    {

        public List<AssignedAdsData> AssignedCourseDataList;

        public void PopulateAssignedCourseData(ApplicationDbContext context,
                                               MyWebSite.Models.User instructor)
        {
            var allAds = context.Ads;
            var instructorAds = new HashSet<int>(
                instructor.AdsAssignments.Select(c => c.AdsID));
            AssignedCourseDataList = new List<AssignedAdsData>();
            foreach (var ads in allAds)
            {
                AssignedCourseDataList.Add(new AssignedAdsData
                {
                    AdsID = ads.AdsID,
                    Title = ads.Title,
                    Assigned = instructorAds.Contains(ads.AdsID)
                });
            }
        }

        public void UpdateInstructorAds(ApplicationDbContext context,
            string[] selectedAds, MyWebSite.Models.User instructorToUpdate)
        {
            if (selectedAds == null)
            {
                instructorToUpdate.AdsAssignments = new List<AdsAssignment>();
                return;
            }

            var selectedAdsHS = new HashSet<string>(selectedAds);
            var instructorAds = new HashSet<int>
                (instructorToUpdate.AdsAssignments.Select(c => c.Ads.AdsID));
            foreach (var ads in context.Ads)
            {
                if (selectedAdsHS.Contains(ads.AdsID.ToString()))
                {
                    if (!instructorAds.Contains(ads.AdsID))
                    {
                        instructorToUpdate.AdsAssignments.Add(
                            new AdsAssignment
                            {
                                UsersID = instructorToUpdate.ID,
                                AdsID = ads.AdsID
                            });
                    }
                }
                else
                {
                    if (instructorAds.Contains(ads.AdsID))
                    {
                        AdsAssignment adsToRemove
                            = instructorToUpdate
                                .AdsAssignments
                                .SingleOrDefault(i => i.AdsID == ads.AdsID);
                        context.Remove(adsToRemove);
                    }
                }
            }
        }
    }
}
