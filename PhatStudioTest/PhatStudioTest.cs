using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhatStudio;

namespace PhatStudioTest
{
    [TestClass]
    public class PhatStudioTest
    {
        public PhatStudioTest()
        {
        }

        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod]
        public void TestBasicFileIndex()
        {
            FileIndex fileIndex = new FileIndex();

            string[] fileList = {
                    @"c:\bah\humbug\foo\bar\123.txt",
                    @"c:\bah\humbug\foo\bar\humbug.txt",
                    @"c:\bah\humbug\foo\bar\cat.txt",
                    @"c:\bah\humbug\cat\dog.txt",
                    @"c:\bah\humbug\cat\dog\animals.txt",
                    @"c:\bah\dog\manyanimals.jpg",
                    @"c:\bah\cat\manyanimals.jpg",
                    @"c:\project\Thing1\obj\output.obj",
                    @"c:\project\Thing2\obj\output.obj",
                    @"c:\project\Thing2\obj\cacaca.obj",
                    @"c:\project\Thing2\obj\bubu.obj",
            };

            foreach (string file in fileList)
            {
                fileIndex.AddFile(file);
            }

            TestFileIndexCase(fileIndex, "123", new string[] { @"c:\bah\humbug\foo\bar\123.txt" });

            TestFileIndexCase(fileIndex, "humbugster", new string[] { });

            TestFileIndexCase(fileIndex, ".t", new string[] { 
                    @"c:\bah\humbug\foo\bar\123.txt",
                    @"c:\bah\humbug\foo\bar\cat.txt",
                    @"c:\bah\humbug\cat\dog.txt",
                    @"c:\bah\humbug\foo\bar\humbug.txt",
                    @"c:\bah\humbug\cat\dog\animals.txt" });

            TestFileIndexCase(fileIndex, "anIM", new string[] { 
                    @"c:\bah\humbug\cat\dog\animals.txt",
                    @"c:\bah\cat\manyanimals.jpg",
                    @"c:\bah\dog\manyanimals.jpg" });

            TestFileIndexCase(fileIndex, "bu", new string[] { 
                    @"c:\project\Thing2\obj\bubu.obj",
                    @"c:\bah\humbug\foo\bar\humbug.txt",
                    @"c:\bah\humbug\cat\dog.txt",
                    @"c:\bah\humbug\cat\dog\animals.txt",
                    @"c:\bah\humbug\foo\bar\123.txt",                    
                    @"c:\bah\humbug\foo\bar\cat.txt" });

            TestFileIndexCase(fileIndex, "obj", new string[] { 
                    @"c:\project\Thing2\obj\bubu.obj" ,
                    @"c:\project\Thing2\obj\cacaca.obj",
                    @"c:\project\Thing1\obj\output.obj",
                    @"c:\project\Thing2\obj\output.obj" });

            TestFileIndexCase(fileIndex, "ing", new string[] { 
                    @"c:\project\Thing1\obj\output.obj",                                        
                    @"c:\project\Thing2\obj\bubu.obj",
                    @"c:\project\Thing2\obj\cacaca.obj",
                    @"c:\project\Thing2\obj\output.obj" });

            TestFileIndexCase(fileIndex, "cat\\", new string[] { 
                    @"c:\bah\cat\manyanimals.jpg",
                    @"c:\bah\humbug\cat\dog.txt",
                    @"c:\bah\humbug\cat\dog\animals.txt" });

            TestFileIndexCase(fileIndex, "humbug\\cat\\", new string[] { 
                    @"c:\bah\humbug\cat\dog.txt",
                    @"c:\bah\humbug\cat\dog\animals.txt" });

            TestFileIndexCase(fileIndex, "at\\", new string[] { 
                    @"c:\bah\cat\manyanimals.jpg",
                    @"c:\bah\humbug\cat\dog.txt",
                    @"c:\bah\humbug\cat\dog\animals.txt" });

            TestFileIndexCase(fileIndex, "cat\\d", new string[] { 
                    @"c:\bah\humbug\cat\dog.txt",
                    @"c:\bah\humbug\cat\dog\animals.txt" });

            TestFileIndexCase(fileIndex, "cat\\a", new string[] {} );

            TestFileIndexCase(fileIndex, "dfgdfgsdgsdgsdfgsdgqrsdfasfadsfgdsg\\humbu", new string[] { });

            TestFileIndexCase(fileIndex, @"Thing1\o", new string[] { 
                    @"c:\project\Thing1\obj\output.obj" } );

            TestFileIndexCase(fileIndex, @"thing2", new string[] { 
                    @"c:\project\Thing2\obj\bubu.obj",
                    @"c:\project\Thing2\obj\cacaca.obj",
                    @"c:\project\Thing2\obj\output.obj"  });

            TestFileIndexCase(fileIndex, @"Thing2\", new string[] { 
                    @"c:\project\Thing2\obj\bubu.obj",
                    @"c:\project\Thing2\obj\cacaca.obj",
                    @"c:\project\Thing2\obj\output.obj"  });

            TestFileIndexCase(fileIndex, @"Thing2", new string[] { 
                    @"c:\project\Thing2\obj\bubu.obj",
                    @"c:\project\Thing2\obj\cacaca.obj",
                    @"c:\project\Thing2\obj\output.obj"  });

            TestFileIndexCase(fileIndex, @"Thing2\ob", new string[] { 
                    @"c:\project\Thing2\obj\bubu.obj",
                    @"c:\project\Thing2\obj\cacaca.obj",
                    @"c:\project\Thing2\obj\output.obj"  });

            TestFileIndexCase(fileIndex, @"thing2\obj", new string[] { 
                    @"c:\project\Thing2\obj\bubu.obj",
                    @"c:\project\Thing2\obj\cacaca.obj",
                    @"c:\project\Thing2\obj\output.obj"  });

            TestFileIndexCase(fileIndex, @"Thing2\obJ\", new string[] { 
                    @"c:\project\Thing2\obj\bubu.obj",
                    @"c:\project\Thing2\obj\cacaca.obj",
                    @"c:\project\Thing2\obj\output.obj"  });

            TestFileIndexCase(fileIndex, @"Thing2\OBJ\B", new string[] { 
                    @"c:\project\Thing2\obj\bubu.obj" });

            TestFileIndexCase(fileIndex, "", new string[] { 
                    @"c:\bah\cat\manyanimals.jpg",
                    @"c:\bah\dog\manyanimals.jpg",
                    @"c:\bah\humbug\cat\dog.txt",
                    @"c:\bah\humbug\cat\dog\animals.txt",
                    @"c:\bah\humbug\foo\bar\123.txt",
                    @"c:\bah\humbug\foo\bar\cat.txt",
                    @"c:\bah\humbug\foo\bar\humbug.txt",
                    @"c:\project\Thing1\obj\output.obj",
                    @"c:\project\Thing2\obj\bubu.obj",
                    @"c:\project\Thing2\obj\cacaca.obj",
                    @"c:\project\Thing2\obj\output.obj" });

            fileIndex.RemoveAll();

            TestFileIndexCase(fileIndex, "obj", new string[] { });
        }

        public void TestFileIndexCase(FileIndex fileIndex, string substr, string[] expectedResults)
        {
            List<FileMatch> results;
            results = fileIndex.FindSubstringMatches(substr);
            CheckFileIndexResults(results, expectedResults);
        }

        public void CheckFileIndexResults(List<FileMatch> results, string[] expectedResults)
        {
            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Count == expectedResults.Length);
            for (int i = 0; i < results.Count; i++)
            {
                Assert.IsTrue(String.Compare(results[i].FullName, expectedResults[i], false) == 0);
            }
        }

        [TestMethod]
        public void TestTrie()
        {
            SuffixTrie trie = new SuffixTrie();

            trie.AddString("cat");
            trie.AddString("catherine");
            trie.AddString("car");
            trie.AddString("cop");
            trie.AddString("transaction");
            trie.AddString("transvestite");
            trie.AddString("interview");
            trie.AddString("yogayoga!");

            TestTrieCase(trie, "abcd", new string[0]);
            TestTrieCase(trie, "c", new string[] { "cat", "catherine", "car", "cop", "transaction" } );
            TestTrieCase(trie, "e", new string[] { "catherine", "transvestite", "interview" });
            TestTrieCase(trie, "ca", new string[] { "cat", "catherine", "car" });
            TestTrieCase(trie, "cat", new string[] { "cat", "catherine" });
            TestTrieCase(trie, "cath", new string[] { "catherine" });
            TestTrieCase(trie, "catherine", new string[] { "catherine" });
            TestTrieCase(trie, "catherine1", new string[0]);
            TestTrieCase(trie, "caq", new string[0]);
            TestTrieCase(trie, "at", new string[] { "cat", "catherine" } );
            TestTrieCase(trie, "in", new string[] { "interview", "catherine" });
            TestTrieCase(trie, "yoga", new string[] { "yogayoga!" });
        }

        public void TestTrieCase(SuffixTrie trie, string substr, string[] expectedResults)
        {
            List<SubstringMatch> results;
            results = trie.FindSubstringMatches(substr);
            CheckTrieResults(results,expectedResults);
        }

        public void CheckTrieResults(List<SubstringMatch> results, string[] expectedResults)
        {
            Assert.IsTrue(results != null);
            Assert.IsTrue(results.Count == expectedResults.Length);
            foreach (string expectedResult in expectedResults)
            {
                bool found = false;
                foreach (SubstringMatch result in results)
                {
                    if (String.Compare(result.Value, expectedResult) == 0)
                    {
                        found = true;
                        break;
                    }
                }
                Assert.IsTrue(found);
            }
        }
    }
}
