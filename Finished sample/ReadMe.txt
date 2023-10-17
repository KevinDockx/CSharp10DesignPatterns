My primary reason for raising this PR was to eliminate the noise distractions of excess warnings 

Some personal preferences caused significant style differences, so I commented those out ("#Dick ") in the .editorconfig to minimse extraneous changes
- feel free to uncomment to taste !

The added .editorconfig file resides here at solution-level. Unusually, it contains the setting
"dotnet_style_namespace_match_folder = false"
to address the 2 projects with peculiar namespace designs
1. Adapter teaches 2 alternates in the same folder but with different namespaces to distinguish
	ClassAdapterImplementation.cs, ObjectAdapterImplementation.cs have same class definitions
	if you set "dotnet_style_namespace_match_folder = true", the classes will collide

2. Builder pattern originally had a "namespace BuilderPattern;", and Program.cs in the minimal style (i.e. implicit namespace)
	but now simplified to match the containing folder structure, so Program needs an explicit "using Builder;" to link-in.
