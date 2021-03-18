using System;
#if ASYNC
using System.Threading.Tasks;
#endif
using ZendeskApi_v2.Extensions;
using ZendeskApi_v2.Models.HelpCenter.Votes;

namespace ZendeskApi_v2.Requests.HelpCenter
{
	public interface IVotes : ICore
	{
#if SYNC

		GroupVoteResponse GetVotesForArticle(long? articleId);
        GroupVoteResponse GetVotesForPost(long? postId);
#endif
#if ASYNC
		Task<GroupVoteResponse> GetVotesForArticleAsync(long? articleId);
        Task<GroupVoteResponse> GetVotesForPostAsync(long? postId);
#endif

	}

	public class Votes : Core, IVotes
	{
		public Votes(string yourZendeskUrl, string user, string password, string apiToken, string p_OAuthToken)
            : base(yourZendeskUrl, user, password, apiToken, p_OAuthToken)
		{
		}

#if SYNC

		public GroupVoteResponse GetVotesForArticle(long? articleId)
		{ 
			return GenericGet<GroupVoteResponse>($"help_center/articles/{articleId}/votes.json");
		}
        
        public GroupVoteResponse GetVotesForPost(long? postId)
		{ 
			return GenericGet<GroupVoteResponse>($"community/posts/{postId}/votes.json");
		}
		
#endif
#if ASYNC

		public async Task<GroupVoteResponse> GetVotesForArticleAsync(long? articleId)
		{
			return await GenericGetAsync<GroupVoteResponse>($"help_center/articles/{articleId}/votes.json");
		}
        
        public async Task<GroupVoteResponse> GetVotesForPostAsync(long? postId)
		{ 
			return await GenericGetAsync<GroupVoteResponse>($"community/posts/{postId}/votes.json");
		}

#endif
	}
}
