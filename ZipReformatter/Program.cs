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

            List<InputZipFile> inputZipFiles = JsonConvert.DeserializeObject<List<InputZipFile>>(File.ReadAllText(@"C:\wipro\zip_asset_output_Sep7\zip_asset_output.json"));

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

                                    if (asset.AssetType == "Video")
                                    {
                                        Console.WriteLine("whoop whoop");
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("It's a different type so wait here");
                            }

                            //Console.WriteLine("hang on here");
                        }
                        if (asset.BrandsDetected)
                        {
                            List<string> brandsToIgnore = new List<string> { "3M", "Scotch Tape", "Post-it Note", "BlueSG", "Scotchgard", "Nexcare", "Scotch-Brite" };

                            outputZipFile.BrandsDetected = true;

                            if (outputZipFile.Brands == null)
                            {
                                outputZipFile.Brands = new();
                            }

                            string thisType = asset.Brands.GetType().ToString();

                            if (thisType == "Newtonsoft.Json.Linq.JArray")
                            {
                                Object innerObject = JsonConvert.DeserializeObject<Object>(asset.Brands.ToString());

                                try
                                {
                                    InputBrand[][] doubleBrandArray = JsonConvert.DeserializeObject<InputBrand[][]>(asset.Brands.ToString());

                                    foreach (InputBrand[] outerArray in doubleBrandArray)
                                    {
                                        foreach (InputBrand innerBrand in outerArray)
                                        {
                                            OutputBrand outputBrand = new OutputBrand(innerBrand);

                                            outputBrand.File = asset.FileName;

                                            if (!brandsToIgnore.Contains(outputBrand.Description))
                                            {
                                                outputZipFile.Brands.Add(outputBrand);
                                            }
                                            else
                                            {
                                                //Console.WriteLine("ha");
                                            }
                                        }

                                    }
                                }
                                //It's only a single array
                                catch (Exception e)
                                {
                                    InputBrand[] singleBrandArray = JsonConvert.DeserializeObject<InputBrand[]>(asset.Brands.ToString());

                                    foreach (InputBrand inputBrand in singleBrandArray)
                                    {
                                        OutputBrand outputBrand = new OutputBrand(inputBrand);

                                        outputBrand.File = asset.FileName;

                                        if (!brandsToIgnore.Contains(outputBrand.Description))
                                        {
                                            outputZipFile.Brands.Add(outputBrand);
                                        }
                                        else
                                        {
                                            //Console.WriteLine("ha");
                                        }
                                    }

                                    //Console.WriteLine("whoop whoop");
                                }
                            }
                            else
                            {
                                Console.WriteLine("It's a different type so wait here");
                            }
                        }
                        if (asset.MusicDetected)
                        {
                            outputZipFile.MusicDetected = true;

                            if (outputZipFile.MusicTimeStamps == null)
                            {
                                outputZipFile.MusicTimeStamps = new();
                            }

                            if (asset.MusicTimeStamps != null)
                            {
                                foreach (MusicTimestamp musicTimeStamp in asset.MusicTimeStamps)
                                {
                                    musicTimeStamp.File = asset.FileName;

                                    outputZipFile.MusicTimeStamps.Add(musicTimeStamp);
                                }
                            }
                        }
                        if (asset.LandmarksDetected)
                        {
                            outputZipFile.LandmarksDetected = true;

                            if (outputZipFile.Landmarks == null)
                            {
                                outputZipFile.Landmarks = new();
                            }

                            string thisType = asset.Landmarks.GetType().ToString();

                            if (thisType == "Newtonsoft.Json.Linq.JArray")
                            {
                                Object innerObject = JsonConvert.DeserializeObject<Object>(asset.Landmarks.ToString());

                                try
                                {
                                    Landmark[][] doubleLandmarkArray = JsonConvert.DeserializeObject<Landmark[][]>(asset.Landmarks.ToString());

                                    foreach (Landmark[] outerArray in doubleLandmarkArray)
                                    {
                                        foreach (Landmark innerLandmark in outerArray)
                                        {
                                            //Landmark outputLandmark = new Landmark(innerLandmark);

                                            innerLandmark.File = asset.FileName;

                                            outputZipFile.Landmarks.Add(innerLandmark);
                                        }

                                    }
                                }
                                //It's only a single array
                                catch (Exception e)
                                {
                                    Landmark[] singleLandmarkArray = JsonConvert.DeserializeObject<Landmark[]>(asset.Landmarks.ToString());

                                    foreach (Landmark inputLandmark in singleLandmarkArray)
                                    {
                                        //OutputBrand outputBrand = new OutputBrand(Landmark);

                                        inputLandmark.File = asset.FileName;

                                        outputZipFile.Landmarks.Add(inputLandmark);
                                    }

                                    //Console.WriteLine("whoop whoop");
                                }
                            }
                            else
                            {
                                Console.WriteLine("It's a different type so wait here");
                            }
                        }
                    }

                    
                }

                //Do a quick check as we may have flagged it as true, but then not added anything because all the brands were on the ignore list
                if ((outputZipFile.Brands == null)||(outputZipFile.Brands.Count == 0))
                {
                    outputZipFile.BrandsDetected = false;
                }
                outputZipFiles.Add(outputZipFile);


            }

            JsonSerializerSettings settings = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, MissingMemberHandling = MissingMemberHandling.Ignore };

            File.WriteAllText(@"C:\wipro\zipoutput.json", JsonConvert.SerializeObject(outputZipFiles, settings));

            Console.WriteLine("Hello World!");
        }
    }
}
