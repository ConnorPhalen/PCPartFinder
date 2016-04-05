using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using System;

namespace PCfinder2
{
    /// <summary>
    /// Performs a search query on a Google Custom Search Engine via an API key and an searchEngineId
    /// and then displays the results to a new tab.
    /// </summary>
    /// @author Connor Phalen
    class SearchFunc
    {
        private const string apiKey = "AIzaSyDyi3LPrzumi8MmH1zNYhzw1JFV39UHaPg";
        private const string searchEngineId = "011076560235305892319:jactn08pzeu";
        private CustomsearchService customSearchService;

        /// <summary>
        /// Constructor that initializes the API key for this object.
        /// </summary>
        public SearchFunc()
        {
            customSearchService = new CustomsearchService(new BaseClientService.Initializer() { ApiKey = apiKey });
        }

        /// <summary>
        /// Takes a query and sends it to the search engine, then displays the results.
        /// </summary>
        /// <param name="query">
        /// The item you want to search for.
        /// </param>
        public Search performSearch(string query)
        {
            // Insert the query and request a List of results and set the engine ID for the search.s
            CseResource.ListRequest listRequest = customSearchService.Cse.List(query);
            listRequest.Cx = searchEngineId;

            // Execute the search request.
            Search results = listRequest.Execute();

            return results;
        }

        /// <summary>
        /// Displays the data from a list of Search results.
        /// </summary>
        /// <param name="results">
        /// The results of a previous Search.
        /// </param>
        private void displaySearch(Search results)
        {
            /* ---- Need to display item price and/or image in tab ---- */

            // Foreach search result, print off the title and website link.
            foreach (Result result in results.Items)
            {
                Console.WriteLine("Title : " + result.Title + "\nLink  : " + result.Link + "\n\n");
            }
        }
    }
}

