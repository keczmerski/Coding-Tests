using System;
using TestBed;
using System.Reflection;
using System.Linq;

namespace SelectAChallenge
{
    class Program
    {
        /// <summary>
        /// On ocassion I want to go through the coding chalenges I have recorded so far and analize them to see if they could be improved uppon. 
        /// In order to do this in a non bias way, I want to select a method at random. The public methods are the challenges and the private methods only assist the challenges.
        /// Other chalenges in other projects and languages will be hard coded in for now. 
        /// Perhaps some time I will find away to automatically include them as well. 
        /// I suppose, this may depend on how long those other lists grow.
        /// </summary>
        /// <param name="args"></param>
        static void Main() { 
        
            MethodInfo[] methodInfoChallenges = typeof(Challenges).GetMethods();
            //MethodInfo[] methodInfoSort_Challengess = typeof(Sort_Challenges).GetMethods();// I think this one is fully investigated so I am not including it anymore
            System.Collections.Generic.List<string> CSharpMethodNames = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> JavaScriptMethodNames = new System.Collections.Generic.List<string>();
            foreach (MethodInfo MethodInfo in methodInfoChallenges)
            {
                string[] filterMethodsThatArePlayedOut = new string[] { "SumOfDigits" };
                if (MethodInfo.IsPublic && !filterMethodsThatArePlayedOut.Contains(MethodInfo.Name))
                {
                    CSharpMethodNames.Add(MethodInfo.Name);
                }
            }
            //foreach (MethodInfo MethodInfo in methodInfoSort_Challengess) // I think this one is fully investigated
            //{
            //    if (MethodInfo.IsPublic)
            //    {
            //        CSharpMethodNames.Add(MethodInfo.Name);
            //    }
            //}
            CSharpMethodNames.Add("SmallWorld");
            CSharpMethodNames.Add("SelectAChalenge");
            JavaScriptMethodNames.Add("FindCharsVowelsFirst");
            JavaScriptMethodNames.Add("Reverser");
            JavaScriptMethodNames.Add("DataMunging");
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            //Console.WriteLine("Study Selector? (Y/N) (If not then you are simply randomly selecting some code to review.)");
            //ConsoleKeyInfo StudySelectorAnswerKey = Console.ReadKey();
            char StudySelectorAnswer = 'y';// StudySelectorAnswerKey.KeyChar;

            bool IsSelectCodeForReview = true;
            string simpleBoarder = "******************************************************************" + System.Environment.NewLine;
            string TextBoarder = System.Environment.NewLine + System.Environment.NewLine + simpleBoarder + simpleBoarder + simpleBoarder + System.Environment.NewLine;

           
            if (StudySelectorAnswer == 'Y' || StudySelectorAnswer == 'y')
            {
                string selectACodeReview = "Select a code review and have it reviewed on Stack overflow/ code reviews.";
                string LearnFacebookEnv = "Get familiar with Facebook’s technical environment";
                string[] Choices = new string[] {
                    "study Rest APIs",
                    "Study Replication add to keyword interview list",
                    "Study Load balancing add to keyword list","study heaps", "Study hash maps","Implement a binary search",
                    "Implement a merge sort", "Study a debth first graph search", "study bredth first search","Study dynamic programming","study back of the envelope calculations?", 
                    "stydy SimpleDB, Dynamo DB and DocumentDB?","Print out a better complexity graph, and put it up on the wall",
                    "study CDN add to keyword list", "study content delivery", "learn more about noSQL add to keyword list", "develop/expand on a map of various ways to handle system design improvement",
                    "Study Graph QL", "study Web Sockets", 
                    "study Sharding",  "study caching", "Make a Keyword List for Interviewing","study casandra",
                    "Study APIs: Post Put Get Delete","Study JSON","Study RPCs", "study offline batch job","study map reduce", "Study s3 add to list of keywords for interview", "develop a list of facebook questions",
                    "Solve a debth first search problem","print out a better algorythm complexity graph",
                    "Study caching","study your resume and expand on good stories",
                    "study load balancing","study consistant hashing",
                    "Study Content Delivery Networks (CDN)","study gateways tcp vs http","watch more youtube interviews",
                    "study concurency","study this design https://github.com/donnemartin/system-design-primer/tree/master/solutions/system_design/social_graph#design-the-data-structures-for-a-social-network",
                    "Solve a DP (Dynamic Programming ) problem",
                    "Linked In Learning: Programming Foundations: Algorithms",
                    "Study this link: https://aws.amazon.com/ec2/",
                    "Study this link: https://aws.amazon.com/eks/","study Message queues",
                    "Study this youtube video! System Design: https://youtu.be/gNQ9-kgyHfo",
                    "Study this youtube video!  Coding Sample: https://youtu.be/mjZpZ_wcYFg",
                    "Read your text book (Or research on line) and study algorythms.",
                    "Read your text book (Or research on line) and study datastructures.",
                    "Create a DataStructure in your coding challenge section.",
                    "Create a sorting algorythm in your coding challenge section.",
                    "Do a Hacker Rank coding challenge.",
                    "Do a LeetCode coding challenge.",
                    "Do a Hacker Rank coding challenge.",
                    "Do a LeetCode coding challenge.",
                    "Okay, okay, study Unity. Sigh.",
                    "Read this: https://engineering.fb.com/core-data/scaling-the-facebook-data-warehouse-to-300-pb/",
                    "Read this: https://thenewstack.io/facebook-storage/",
                    "Read this: https://www.computerweekly.com/news/2240222266/Facebook-shares-lessons-learnt-from-deploying-Raid-in-HDFS-clusters",
                    "https://www.bing.com/videos/search?view=detail&mid=59190B8D5A52DE9C692959190B8D5A52DE9C6929&shtp=GetUrl&shid=e0ce3904-22d4-4891-a0cd-ffe79883bc43&shtk=QSBmcmllbmRseSBpbnRyb2R1Y3Rpb24gdG8gU3lzdGVtIERlc2lnbg%3D%3D&shdk=VGhpcyBpcyBhbiBpbnRyb2R1Y3Rpb24gdG8gU3lzdGVtIERlc2lnbiwgd2hlcmUgd2UgdGFsayBhYm91dCBidWlsZGluZyBsYXJnZSBzY2FsZSBzeXN0ZW1zIGxpa2UgR29vZ2xlLCBGYWNlYm9vaywgQW1hem9uIGFuZCBUd2l0dGVyLiBNaWxsaW9ucyBvZiB1c2VycyB0cnVzdCB0aGVzZSBzaXRlcyB0byBhbHdheXMgd29yay5UaGlzIHJlcXVpcmVzIGV4Y2VsbGVudCBlbmdpbmVlcmluZyBvbiB0aGUgc2VydmVyIHNpZGUuIFRoZSBiYWNrZW5kIGVuZ2luZWVycyBuZWVkIHRvIHRha2UgdmFyaW91cyB0aGluZ3MgaW50byBjb25zaWRlcmF0aW9uLiBMaWtlIGxvYWQgYmFsYW5jaW5nLCBmYXVsdCAuLi4%3D&shhk=KjQ5H13VbFeUqf%2FNuaEw%2BxwNnnFS1lk8rfOmwwoihLI%3D&form=VDSHOT&shth=OSH.HgM3L34kZ%252FBwsZQHZqcL%252Fw",
                    "https://youtu.be/UH7wkvcf0ys?list=PL_ODyL-jNdIAbwqJ-_hcrpgqsbeF1dLgt",
                    "https://www.bing.com/videos/search?view=detail&mid=668C28AF37205FEEE8C7668C28AF37205FEEE8C7&shtp=GetUrl&shid=7656d0a3-b1e0-4570-a265-9aaaa7874708&shtk=V2hhdCBpcyBTeXN0ZW0gRGVzaWduPw%3D%3D&shdk=VG9kYXksIHdlIGFyZSBnb2luZyB0byBsZWFybiAiV2hhdCBpcyBTeXN0ZW0gRGVzaWduPyIuIFRoZSBnb2FsIGlzIHRvIG1ha2UgeW91IHVuZGVyc3RhbmQgd2hhdCBpcyBTeXN0ZW0gRGVzaWduIHdoaWNoIG1lYW5zIHRoYXQgdGhlcmUgYXJlIGZldyBzaW1wbGlmaWNhdGlvbnMgZG9uZSB3aGlsZSBjcmVhdGluZyB0aGlzLiBTeXN0ZW0gRGVzaWduIFNlcmllcyBQbGF5bGlzdDogaHR0cHM6Ly93d3cueW91dHViZS5jb20vcGxheWxpc3Q%2FbGlzdD1QTHFPaWFIOWlkNXF0RDdoOFp3dTFhYmpLVUx0VnEwblFBIEJsb2cgcG9zdDogaHR0cHM6Ly9hZnRlcmFjYWRlbXkuY29tL2Jsb2cvd2hhdC1pcy1zeXN0ZW0gLi4u&shhk=rAASZmIH8FaalkktmWQka3liofz%2BfIfme6Fv1%2FAWZe0%3D&form=VDSHOT&shth=OSH.SigkeoIFW5XYxwWVuNU3Og",
                    "https://www.bing.com/videos/search?view=detail&mid=70B155423540851DB97670B155423540851DB976&shtp=GetUrl&shid=090f3313-69f6-4d51-8d8f-dd493bc3c445&shtk=U3lzdGVtIERlc2lnbjogU3BvdGlmeSB8IFlvdVR1YmUgTXVzaWMgfCBBcHBsZSBNdXNpYyBTdHJlYW1pbmcgc2VydmljZXM%3D&shdk=U3BvdGlmeSBpcyBhIHBvcHVsYXIgc3RyZWFtaW5nIHNlcnZpY2UgYW5kIG9wZXJhdGVzIGdsb2JhbGx5LiBJbiB0aGlzLCBJIGhhdmUgdGFsa2VkIGFib3V0IGhpZ2ggbGV2ZWwgZGVzaWduIG9mIFNwb3RpZnkuY29tIGFuZCBpcyBhcHBsaWNhYmxlIGZvciBvdGhlciBzdHJlYW1pbmcgc2VydmljZSBsaWtlIEFwcGxlIE11c2ljLCBZb3VUdWJlIG11c2ljIGV0Yy4gSSBoYXZlIGNvdmVyZWQgdGhlIEFQSSwgZGF0YWJhc2UsIE1lZGlhIHNlcnZlciBhbmQgdGVjaCBzdGFjay4gVGhpcyBpcyBhbHNvIGFza2VkIGluIFN5c3RlbSBkZXNpZ24gaW50ZXJ2aWV3IHF1ZXN0aW9ucyBhdCBBbWF6b24uY29tIC4uLg%3D%3D&shhk=otzeN%2BIOkN9oVj7sb%2BwMlZ%2BF28mqvHAyWdgY%2FZyisys%3D&form=VDSHOT&shth=OSH.X0lykyHt5VjG%252BW7uYsg3rg",
                    "https://www.bing.com/videos/search?view=detail&mid=FD968CBC44E3BCEC4C3EFD968CBC44E3BCEC4C3E&shtp=GetUrl&shid=19957457-4719-480e-8d52-d44a07721355&shtk=TmV0ZmxpeCBTeXN0ZW0gRGVzaWduIHwgTWVkaWEgU3RyZWFtaW5nIFBsYXRmb3JtIHwgU3lzdGVtIERlc2lnbiBJbnRlcnZpZXc%3D&shdk=SW4gdGhpcyB2aWRlbywgd2Ugd2lsbCBzZWUgaG93IHRvIGRlc2lnbiBhIE1lZGlhLXN0cmVhbWluZyBwbGF0Zm9ybSBsaWtlIE5ldGZsaXguIFdlIHdpbGwgc2VlIGhvdyB0byBicmVhayBkb3duIGEgZ2lhbnQgc3lzdGVtIGxpa2UgTmV0ZmxpeCBpbnRvIHNtYWxsIGNvbXBvbmVudHMuIEFmdGVyd2FyZHMsIGhvdyB0byBhcmNoaXRlY3QgZWFjaCBzaW5nbGUgY29tcG9uZW50IHdoaWxlIGJlaW5nIGF3YXJlIG9mIHN5c3RlbSdzIHBlcmZvcm1hbmNlIGFuZCByZWxpYWJpbGl0eSBjb25zdHJhaW50cy4gV2Ugd2lsbCBhbHNvIGNvdmVyIHRoZSBzeXN0ZW0gZGVzaWduIGZyb20gYSByZWFsLWludGVydmlldyAuLi4%3D&shhk=7lEVn950ZJR3ytZmQ4hc3a%2FfN3ldHqImw1LIO%2FTOyhM%3D&form=VDSHOT&shth=OSH.5rs3Z4oaRZcUmgoufbWfsA",
                    "https://www.bing.com/videos/search?view=detail&mid=B7D318BAEC013B8CB2E1B7D318BAEC013B8CB2E1&shtp=GetUrl&shid=53049744-b799-4417-818b-742275f9f7bf&shtk=SW5zdGFncmFtIFN5c3RlbSBEZXNpZ24gfCBEZXNpZ24gUGhvdG8tU2hhcmluZyBBcHBsaWNhdGlvbiB8IFN5c3RlbSBEZXNpZ24gSW50ZXJ2aWV3&shdk=SW4gdGhpcyB2aWRlbywgd2Ugd2lsbCBzZWUgaG93IHRvIGRlc2lnbiBhIFBob3RvLVNoYXJpbmcgYXBwbGljYXRpb24gbGlrZSBJbnN0YWdyYW0uIFdlIHdpbGwgc2VlIGhvdyB0byBicmVhayBkb3duIGEgZ2lhbnQgc3lzdGVtIGxpa2UgSW5zdGFncmFtIGludG8gc21hbGwgY29tcG9uZW50cyBsaWtlIFBob3RvLXVwbG9hZGVyLCBVc2VyLUZlZWQgZ2VuZXJhdG9yIGFuZCBMaWtlL0NvbW1lbnQgUmVjb3JkZXIgYWthIFBob3RvIFJlYWN0aW9ucy4gV2Ugd2lsbCBzZWUgaG93IHdlIGNhbiBsZXZlcmFnZSBzb21lIGN1dHRpbmcgZWRnZSB0ZWNobm9sb2dpZXMgbGlrZSBHcmFwaCBEYXRhYmFzZXMgYW5kIC4uLg%3D%3D&shhk=dhcJxgoxTlFONoeJCxkYROeSqihgjGLGYZMuMRe8iR8%3D&form=VDSHOT&shth=OSH.Kym%252B5ax96Qg%252FLXjL6AVllA",
                    "https://www.bing.com/videos/search?view=detail&mid=4CE18B78055AD19091D84CE18B78055AD19091D8&shtp=GetUrl&shid=11e82fa2-5c09-4dd0-9f05-969f6bb449ca&shtk=U3lzdGVtIERlc2lnbiA6IDQgVGlwcyBmb3IgQ3JhY2tpbmcgU3lzdGVtIERlc2lnbiBJbnRlcnZpZXc%3D&shdk=U3lzdGVtIERlc2lnbiA6IDQgVGlwcyBmb3IgQ3JhY2tpbmcgU3lzdGVtIERlc2lnbiBJbnRlcnZpZXcgSW4gdGhpcyB2aWRlbyBJIGdpdmUgNCBpbXBvcnRhbnQgVGlwcyBmb3IgU3lzdGVtIERlc2lnbiBJbnRlcnZpZXdzLiBUaGVzZSB0aXBzIGFyZTogMS4gTGV2ZXJhZ2UgeW91ciBFeGlzdGluZyBLbm93bGVkZ2UgMi4gVW5kZXJzdGFuZCB0aGUgUHJvYmxlbSB2ZXJ5IHdlbGw6IChBc2sgUXVlc3Rpb25zKSAzLiBIaWdoIExldmVsIEFyY2hpdGVjdHVyZSBEZXNpZ24gKEFic3RyYWN0IERlc2lnbikgNC4gR28gRGVlcCBpbnRvIENvbXBvbmVudCBvZiBJbnRlcmVzdCAqKioqIEJlc3QgQm9va3MgRm9yIC4uLg%3D%3D&shhk=LJNCyyx95gFqClUgfhEK9yNNJa3IBPTkRM2Ff%2Fiz%2B0E%3D&form=VDSHOT&shth=OSH.1ztD9N1cng5MoTir2pFzSg",
                    "https://www.bing.com/videos/search?view=detail&mid=EC29C87ECC02C674F1EAEC29C87ECC02C674F1EA&shtp=GetUrl&shid=ed52be4f-f6d0-4073-b75c-1d9a5b6cc449&shtk=V2hhdCBpcyBhbiBBUEkgYW5kIGhvdyBkbyB5b3UgZGVzaWduIGl0Pw%3D%3D&shdk=QW4gQVBJIG9yIGFwcGxpY2F0aW9uIHByb2dyYW1tYWJsZSBpbnRlcmZhY2UgaXMgYSBzb2Z0d2FyZSBjb250cmFjdCB3aGljaCBkZWZpbmVzIHRoZSBleHBlY3RhdGlvbnMgYW5kIGludGVyYWN0aW9ucyBvZiBhIHBpZWNlIG9mIGNvZGUgZXhwb3NlZCB0byBleHRlcm5hbCB1c2Vycy4gVGhpcyBpbmNsdWRlcyB0aGUgcGFyYW1ldGVycywgcmVzcG9uc2UsIGVycm9ycyBhbmQgQVBJIG5hbWUuIFdlIGRpc2N1c3MgaG93IHRvIGRlc2lnbiBhbiBBUEkgYW5kIHdoYXQgaXQgdGFrZXMgdG8gbWFrZSB0aGUgZGVzaWduIHNjYWxhYmxlLCBleHRlbnNpYmxlIGFuZCBlYXN5IHRvIHVzZS4gSFRUUCBBUElzIGFyZSAuLi4%3D&shhk=2u0KBDw%2FY1NxltQMiopeOR8WhwMmvDsvj8KqIAZaf1I%3D&form=VDSHOT&shth=OSH.rvVNuxZzTbiMMsly3VZH2Q",
                    "Study Graph Theory",
                    "Study combinatorial problems",
                    "find the 4th-largest item in the set",
                    "Study Facebook interviewing",
                    "Study Product Design/System Design: Study client server architectures",
                    "Study Product Design/System Design: Study Scalibility issues within the subject matter.",
                    "Study Product Design/System Design: study design paterns",
                    "Study System Design: Practice using Google drawings by copying the drawings and words said in aa youtube example",
                    "Study Product Design: Practice using Google drawings by copying the drawings and words said in aa youtube example",
                    "Study System Design: Practice using Google drawings by copying the drawings and words said in aa youtube example",
                    "Study Product Design: Practice using Google drawings by copying the drawings and words said in aa youtube example",
                    "Memorize the and understand following questions:" + System.Environment.NewLine +
                    "How many users are we talking about?" + System.Environment.NewLine +
                    "How many messages sent?" + System.Environment.NewLine +
                    "How many messages read?" + System.Environment.NewLine +
                    "What are the latency requirements for sender-- receiver message delivery ?" + System.Environment.NewLine +
                    "How are you going to store messages ?" + System.Environment.NewLine +
                    "What operations does this data store need to support ?" + System.Environment.NewLine +
                    " What operations is it optimized for?",
                    "How do you store mail, especially as the system gets large enough that it won’t fit on one machine ?",
                    "How do you handle mailing lists with large numbers of recipients?",
                    "How do you handle people abusing the system for spam ?",
                    "How do you guarantee the reliability of the system in the face of potential system failures?",
                    "Weigh multiple approaches and reflect on the tradeoffs in design:" + System.Environment.NewLine +
                    " Easy-to-build APIs vs. long-term APIs" + System.Environment.NewLine +
                    "UI complexity vs. server complexity" + System.Environment.NewLine +
                    "Payload size vs. performance",
                    "Study Product Design: Design a service or product API",
                    "Study Product Design: Design a chat service or a feed API",
                    "Study Product Design: Design an email server",
                    "Take any well-known app and imagine you’re going to build the primary feature. For example," + System.Environment.NewLine +
                    "imagine you’re going to build video distribution for Facebook Video, or group chat for WhatsApp." + System.Environment.NewLine +
                    "Now figure out how you would build the various pieces out:" + System.Environment.NewLine +
                    " How would you build your backend storage ? How does that scale to Facebook’s size ?" + System.Environment.NewLine +
                    "How would you lay out the application server layer ? What are the responsibilities of the" + System.Environment.NewLine +
                    "various services ?" + System.Environment.NewLine +
                    "How would you design your mobile API ? What are the hard problems in representing the" + System.Environment.NewLine +
                    "data being sent from server to client ?" + System.Environment.NewLine +
                    "How would you structure your mobile client ? How do low - end devices and poor network" + System.Environment.NewLine +
                    "conditions affect your design ?" + System.Environment.NewLine +
                    "As you’re designing these systems, run through the list of things we’re looking for and make" + System.Environment.NewLine +
                    "Sure you’re able to answer them all for each piece of each app.",
                    "Study Product Design",
                    "Study the following concepts:  Performance vs. scalability; Latency vs. throughput; Availability vs. consistency ",
                    "Study Architect a worldwide video distribution system (System and product design)",
                    "Build Facebook chat(System and product design)",
                    "Design a mobile image search client(System and product design)",
                    "Caching(System and product design)",
                    "Database partitioning, replication, sharding, CAP Theorem (System and product design)",
                    "Networking (IPC, TCP/IP) (System and product design)",
                    "Real-world performance (relative performance RAM, disk, your network, SSD)(System and product design)",
                    "Availability and reliability (types of failures, failure units, how failures may manifest, mitigations, etc.)(System and product design)",
                    "Data storage and data aggregation(System and product design)",
                    "QPS capacity / machine estimation (back of the envelope estimates), byte size estimation(System and product design)",
                    "remind yourself what the STAR answering technique is and follow it through with a practice STAR question.",
                    "Study facebook company values http://www.facebook.com/careers",
                    "Study Interviews on youTube (cached on your phone)",
                    "Study Interviews on youTube: https://www.educative.io/collection/5668639101419520/5649050225344512",
                    "Study Interviews on youTube: https://github.com/donnemartin/system-design-primer",
                    "Study Interviews on youTube: https://www.quora.com/How-do-I-prepare-to-answer-design-questions-in-a-technical-interview",
                    "Study Interviews on youTube: https://www.hiredintech.com/courses/system-design",
                    "Study this website and look specifically for facebook values: https://www.facebook.com/careers",
                    "Answer the question, what do you like about being a developer?",
                    " identifying examples of situations where your behaviors or actions have resulted in" + System.Environment.NewLine +
                    "positive outcomes or illustrate your skills in leadership, teamwork, planning, taking initiative, and" + System.Environment.NewLine +
                    "customer service",
                    "Think beyond your work experience. You can share examples of coursework, internships," + System.Environment.NewLine +
                    "hobby projects, volunteer work, etc. If possible, include different types of examples to showcase" + System.Environment.NewLine +
                    "the breadth of your skills in different situations.: develop a cool list of things you have done outside of work",
                    "Think about challenges and what you’ve learned. Think through the tough situations you’ve" + System.Environment.NewLine +
                    "faced and explain what you’ve learned from each. Keep in mind that sharing some examples with" + System.Environment.NewLine +
                    "negative results can effectively highlight your strengths in the face of adversity and showcase your" + System.Environment.NewLine +
                    "openness to learn and grow.",
                    "Watch a youtube on the STAR system thing",
                    "Write up a challenge that you have handled in your past, Provide specific examples about what you did and the resulting impact, Use STAR system,",
                    "Comunicate with someone at facebook : https://www.facebook.com/fbconnections/candidate/?token=3R9oPnpoN79Su6RomnaFVZYoEMqkBLWkolR7Q5BGhGgfWl4wlDh4Xf2axUAeRo4M&id=152152928532242",
                    LearnFacebookEnv,
                    LearnFacebookEnv,
                    LearnFacebookEnv,
                    LearnFacebookEnv,
                    selectACodeReview,
                    selectACodeReview,
                    selectACodeReview,
                    selectACodeReview,
                    "Study something relavant on LinkedIn Learning Linda"
                };
                int StudySelectorSelection = rand.Next(0, Choices.Count());
                Console.WriteLine(TextBoarder + $"{Choices[StudySelectorSelection]}" + TextBoarder);
                if (!String.Equals(selectACodeReview, Choices[StudySelectorSelection]))
                {
                    IsSelectCodeForReview = false;
                }
                if (String.Equals(LearnFacebookEnv, Choices[StudySelectorSelection]))
                {
                    string[] FacebookTechnicalEnvLinks = new string[] {
                        "https://www.facebook.com/Engineering",
                        "https://code.fb.com/videos/",
                        "https://opensource.fb.com/",
                        "https://www.facebook.com/careers/life/engineering-leadership-at-facebook",
                    };
                    int StudySelectorLearnFacebookEnvSelection = rand.Next(0, FacebookTechnicalEnvLinks.Count());
                    Console.WriteLine(TextBoarder + $"Follow this link and study some of what is there: {FacebookTechnicalEnvLinks[StudySelectorLearnFacebookEnvSelection]}" + TextBoarder);
                }
            }


            if (IsSelectCodeForReview)
            {
                Console.WriteLine();
                Console.WriteLine("C#, JavaScript, or All?");
                Console.WriteLine();
                ConsoleKeyInfo answerKey = Console.ReadKey();
                char answer = answerKey.KeyChar;

                if (answer == 'c' || answer == 'C')
                {
                    int CSharpSelection = rand.Next(0, CSharpMethodNames.Count - 1);
                    Console.WriteLine($"C# answer: {CSharpMethodNames[CSharpSelection]}");
                }
                else if (answer == 'j' || answer == 'J')
                {
                    int JSSelection = rand.Next(0, JavaScriptMethodNames.Count - 1);
                    Console.WriteLine($"JS answer: {JavaScriptMethodNames[JSSelection]}");
                }
                else
                {
                    System.Collections.Generic.List<string> AllMethodNames = new System.Collections.Generic.List<string>();
                    AllMethodNames.AddRange(CSharpMethodNames);
                    AllMethodNames.AddRange(JavaScriptMethodNames);
                    int AllSelection = rand.Next(0, AllMethodNames.Count - 1);
                    Console.WriteLine($"All answer: {AllMethodNames[AllSelection]}");
                }
                Console.WriteLine(TextBoarder);
            }
            Console.WriteLine("Select any key to close.");
            Console.ReadLine();
            Console.WriteLine($"Application complete.");
        }
    }
}
