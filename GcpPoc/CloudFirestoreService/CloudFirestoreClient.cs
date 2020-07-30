using System;
using System.Collections.Generic;
using Google.Cloud.Firestore;

namespace CloudFirestoreService
{
    public class CloudFirestoreClient
    {
        private const string projectId = "gcp-poc-284907";

        public async IAsyncEnumerable<string> GetBooks()
        {
            //Uncomment to test locally
            //string credential_path = @"C:\Users\skopacz\Desktop\gcp-poc-e3e9510aba44.json";
            //System.Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credential_path);

            FirestoreDb db = FirestoreDb.Create(projectId);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", projectId);

            CollectionReference collectionReference = db.Collection("books");
            QuerySnapshot snapshot = await collectionReference.GetSnapshotAsync();
            foreach (DocumentSnapshot document in snapshot.Documents)
            {
                Dictionary<string, object> documentDictionary = document.ToDictionary();

                yield return
                    $@"Document id: {document.Id}; Book title: {documentDictionary["title"]}; Book author: {documentDictionary["author"]}";
            }
        }
    }
}
