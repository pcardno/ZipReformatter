using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;

namespace ZipReformatter
{
    class Program
    {
        static void Main(string[] args)
        {

            List<InputZipFile> inputZipFiles = JsonConvert.DeserializeObject<List<InputZipFile>>(File.ReadAllText(@"C:\wipro\usable zip data.json"));

            List<OutputZipFile> outputZipFiles = new();

            foreach(InputZipFile inputZipFile in inputZipFiles)
            {
                OutputZipFile outputZipFile = new();

                outputZipFile.AssetID = inputZipFile.AssetID;

                outputZipFile.AssetURL = inputZipFile.AssetURL;

                outputZipFile.AssetType = inputZipFile.AssetType;

                outputZipFile.FileType = inputZipFile.FileType;

                outputZipFile.Filename = inputZipFile.Filename;

                outputZipFile.GCPURL = inputZipFile.GCPURL;

                if(inputZipFile.Components != null)
                {
                    foreach (Asset asset in inputZipFile.Components)
                    {
                        if (asset.FacesDetected)
                        {
                            outputZipFile.FacesDetected = true;

                            if (outputZipFile.Faces == null)
                            { 
                                outputZipFile.Faces = new();
                            }

                            string thisType = asset.Faces.GetType().ToString();

                            if (thisType == "Newtonsoft.Json.Linq.JArray")
                            {
                                Object innerObject = JsonConvert.DeserializeObject<Object>(asset.Faces.ToString());

                                try
                                {
                                    InputFace[][] doubleFaceArray = JsonConvert.DeserializeObject<InputFace[][]>(asset.Faces.ToString());

                                    foreach (InputFace[] outerArray in doubleFaceArray)
                                    {
                                        foreach(InputFace innerFace in outerArray)
                                        {
                                            OutputFace outputFace = new OutputFace(innerFace);

                                            outputFace.File = asset.FileName;

                                            outputZipFile.Faces.Add(outputFace);
                                        }

                                    }
                                }
                                //It's only a single array
                                catch (Exception e)
                                {
                                    InputFace[] singleFaceArray = JsonConvert.DeserializeObject<InputFace[]>(asset.Faces.ToString());

                                    foreach (InputFace inputFace in singleFaceArray)
                                    {
                                        OutputFace outputFace = new OutputFace(inputFace);

                                        outputFace.File = asset.FileName;

                                        outputZipFile.Faces.Add(outputFace);
                                    }

                                    //Console.WriteLine("whoop whoop");
                                }

                                /*
                                string thisInnerType = innerObject.GetType().ToString();

                                //It's an array within an array for some stupid reason
                                if (thisInnerType == "Newtonsoft.Json.Linq.JArray")
                                {
                                    Object myInnerArray = JsonConvert.DeserializeObject<Object>(innerObject.ToString());

                                    List<InputFace> myFaces = JsonConvert.DeserializeObject<List<InputFace>>(myInnerArray.ToString());

                                    Console.WriteLine("hang on here2");
                                }

                                //List<Face> myFaces = JsonConvert.DeserializeObject<List<Face>>(asset.Faces.ToString());

                                Console.WriteLine("hang on here1");
                                */
                            }
                            else
                            {
                                Console.WriteLine("It's a different type so wait here");
                            }

                            //Console.WriteLine("hang on here");
                        }
                        if (asset.BrandsDetected)
                        {
                            outputZipFile.BrandsDetected = true;
                        }
                        if (asset.MusicDetected)
                        {
                            outputZipFile.MusicDetected = true;
                        }
                        if (asset.LandmarksDetected)
                        {
                            outputZipFile.LandmarksDetected = true;
                        }
                    }
                }

                outputZipFiles.Add(outputZipFile);


            }

            JsonSerializerSettings settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };

            File.WriteAllText(@"C:\wipro\zipoutput.json", JsonConvert.SerializeObject(outputZipFiles, settings));

            Console.WriteLine("Hello World!");
        }
    }
}
