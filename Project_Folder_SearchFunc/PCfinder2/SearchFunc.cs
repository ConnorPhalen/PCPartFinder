using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using System;
using System.Windows;

namespace PCfinder2
{
    /// <summary>
    /// Performs a search query on a Google Custom Search Engine via an API key and an searchEngineId
    /// and then displays the results to a new tab.
    /// </summary>
    /// @author Connor Phalen
    class SearchFunc
    {
        /* // Old Search Engine 
            private const string apiKey = "AIzaSyDyi3LPrzumi8MmH1zNYhzw1JFV39UHaPg";
            private const string searchEngineId = "011076560235305892319:jactn08pzeu";
        */

        private const string apiKey = "AIzaSyC5DrrxCV2a647TvDad3bzRcbGqRUiEIPo";
        private const string searchEngineId = "010138963599061418749:o9c8fsl6qwk";
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
            try
            {
                // Insert the query and request a List of results and set the engine ID for the search.s
                CseResource.ListRequest listRequest = customSearchService.Cse.List(query);
                listRequest.Cx = searchEngineId;

                // Execute the search request.
                Search results = listRequest.Execute();

                return results;
            }
            catch(System.Net.Http.HttpRequestException ex)
            {
                MessageBox.Show("Search Request Could not be completed.");
                return new Search();
            }
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

