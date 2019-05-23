namespace Microsoft.Graph.DotnetCore.Test.Requests.Functional
{
    using System.Threading.Tasks;
    using Xunit;

    public class GroupTests : GraphTestBase
    {
        /// <summary>
        /// Create a team on a group.
        /// </summary>
        [Fact(Skip = "No CI set up for functional tests")]
        public async Task GroupCreateTeam()
        {
            try
            {
                // Get a groups collection. We'll use the first entry to add the team. Results in a call to the service.
                IGraphServiceGroupsCollectionPage groupPage = await graphClient.Groups.Request().GetAsync();

                // Create a team with settings.
                Team team = new Team()
                {
                    MemberSettings = new TeamMemberSettings()
                    {
                        AllowCreateUpdateChannels = true
                    }
                };

                // Add a team to the group.  Results in a call to the service.
                await graphClient.Groups[groupPage[8].Id].Team.Request().PutAsync(team);
            }
            catch (ServiceException e)
            {
                Assert.True(false, e.Error.ToString());
            }
        }
    }
}
