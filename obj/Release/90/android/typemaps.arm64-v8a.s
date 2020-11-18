	.arch	armv8-a
	.file	"typemaps.arm64-v8a.s"

/* map_module_count: START */
	.section	.rodata.map_module_count,"a",@progbits
	.type	map_module_count, @object
	.p2align	2
	.global	map_module_count
map_module_count:
	.size	map_module_count, 4
	.word	21
/* map_module_count: END */

/* java_type_count: START */
	.section	.rodata.java_type_count,"a",@progbits
	.type	java_type_count, @object
	.p2align	2
	.global	java_type_count
java_type_count:
	.size	java_type_count, 4
	.word	384
/* java_type_count: END */

/* java_name_width: START */
	.section	.rodata.java_name_width,"a",@progbits
	.type	java_name_width, @object
	.p2align	2
	.global	java_name_width
java_name_width:
	.size	java_name_width, 4
	.word	92
/* java_name_width: END */

	.include	"typemaps.shared.inc"
	.include	"typemaps.arm64-v8a-managed.inc"

/* Managed to Java map: START */
	.section	.data.rel.map_modules,"aw",@progbits
	.type	map_modules, @object
	.p2align	3
	.global	map_modules
map_modules:
	/* module_uuid: 08f11f00-9755-4d42-90e8-4d8b901fa3df */
	.byte	0x00, 0x1f, 0xf1, 0x08, 0x55, 0x97, 0x42, 0x4d, 0x90, 0xe8, 0x4d, 0x8b, 0x90, 0x1f, 0xa3, 0xdf
	/* entry_count */
	.word	3
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module0_managed_to_java
	/* duplicate_map */
	.xword	module0_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.CoordinatorLayout */
	.xword	.L.map_aname.0
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 59745102-39c2-43b1-b4a1-94d3cef1a4be */
	.byte	0x02, 0x51, 0x74, 0x59, 0xc2, 0x39, 0xb1, 0x43, 0xb4, 0xa1, 0x94, 0xd3, 0xce, 0xf1, 0xa4, 0xbe
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module1_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.GooglePlayServices.Base */
	.xword	.L.map_aname.1
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 34fe8c10-7514-4bc5-9ac1-d763a1c68e7e */
	.byte	0x10, 0x8c, 0xfe, 0x34, 0x14, 0x75, 0xc5, 0x4b, 0x9a, 0xc1, 0xd7, 0x63, 0xa1, 0xc6, 0x8e, 0x7e
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module2_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.AndroidX.CustomView */
	.xword	.L.map_aname.2
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: d8e65f2a-f6a4-40e1-b194-548d59cfa6a2 */
	.byte	0x2a, 0x5f, 0xe6, 0xd8, 0xa4, 0xf6, 0xe1, 0x40, 0xb1, 0x94, 0x54, 0x8d, 0x59, 0xcf, 0xa6, 0xa2
	/* entry_count */
	.word	3
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module3_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.AndroidX.DrawerLayout */
	.xword	.L.map_aname.3
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 3d010f2b-3d56-475b-8b98-0a6ff8028ad4 */
	.byte	0x2b, 0x0f, 0x01, 0x3d, 0x56, 0x3d, 0x5b, 0x47, 0x8b, 0x98, 0x0a, 0x6f, 0xf8, 0x02, 0x8a, 0xd4
	/* entry_count */
	.word	30
	/* duplicate_count */
	.word	4
	/* map */
	.xword	module4_managed_to_java
	/* duplicate_map */
	.xword	module4_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.AppCompat */
	.xword	.L.map_aname.4
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 65c82135-859c-4792-9ef7-a2669f58f513 */
	.byte	0x35, 0x21, 0xc8, 0x65, 0x9c, 0x85, 0x92, 0x47, 0x9e, 0xf7, 0xa2, 0x66, 0x9f, 0x58, 0xf5, 0x13
	/* entry_count */
	.word	30
	/* duplicate_count */
	.word	2
	/* map */
	.xword	module5_managed_to_java
	/* duplicate_map */
	.xword	module5_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Core */
	.xword	.L.map_aname.5
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 547aa242-6f63-4428-84b5-eb0994e6f1fe */
	.byte	0x42, 0xa2, 0x7a, 0x54, 0x63, 0x6f, 0x28, 0x44, 0x84, 0xb5, 0xeb, 0x09, 0x94, 0xe6, 0xf1, 0xfe
	/* entry_count */
	.word	233
	/* duplicate_count */
	.word	42
	/* map */
	.xword	module6_managed_to_java
	/* duplicate_map */
	.xword	module6_managed_to_java_duplicates
	/* assembly_name: Mono.Android */
	.xword	.L.map_aname.6
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 75edd548-306c-410c-a4f2-85f5f9d14fff */
	.byte	0x48, 0xd5, 0xed, 0x75, 0x6c, 0x30, 0x0c, 0x41, 0xa4, 0xf2, 0x85, 0xf5, 0xf9, 0xd1, 0x4f, 0xff
	/* entry_count */
	.word	15
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module7_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.GooglePlayServices.Vision */
	.xword	.L.map_aname.7
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 4dddab61-3704-4dea-8031-e9caeb06696d */
	.byte	0x61, 0xab, 0xdd, 0x4d, 0x04, 0x37, 0xea, 0x4d, 0x80, 0x31, 0xe9, 0xca, 0xeb, 0x06, 0x69, 0x6d
	/* entry_count */
	.word	2
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module8_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: QrData */
	.xword	.L.map_aname.8
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 4a550e6c-f015-45f0-b307-dcf2262b36ad */
	.byte	0x6c, 0x0e, 0x55, 0x4a, 0x15, 0xf0, 0xf0, 0x45, 0xb3, 0x07, 0xdc, 0xf2, 0x26, 0x2b, 0x36, 0xad
	/* entry_count */
	.word	10
	/* duplicate_count */
	.word	3
	/* map */
	.xword	module9_managed_to_java
	/* duplicate_map */
	.xword	module9_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Fragment */
	.xword	.L.map_aname.9
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: c356797a-b3a1-47e2-8ad0-befa157ca567 */
	.byte	0x7a, 0x79, 0x56, 0xc3, 0xa1, 0xb3, 0xe2, 0x47, 0x8a, 0xd0, 0xbe, 0xfa, 0x15, 0x7c, 0xa5, 0x67
	/* entry_count */
	.word	11
	/* duplicate_count */
	.word	2
	/* map */
	.xword	module10_managed_to_java
	/* duplicate_map */
	.xword	module10_managed_to_java_duplicates
	/* assembly_name: Xamarin.GooglePlayServices.Tasks */
	.xword	.L.map_aname.10
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 662bb88d-1440-46fd-bcbd-adbe988ca497 */
	.byte	0x8d, 0xb8, 0x2b, 0x66, 0x40, 0x14, 0xfd, 0x46, 0xbc, 0xbd, 0xad, 0xbe, 0x98, 0x8c, 0xa4, 0x97
	/* entry_count */
	.word	4
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module11_managed_to_java
	/* duplicate_map */
	.xword	module11_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Activity */
	.xword	.L.map_aname.11
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: f9bcc2c4-babb-44ab-be0e-6edbe560dcd7 */
	.byte	0xc4, 0xc2, 0xbc, 0xf9, 0xbb, 0xba, 0xab, 0x44, 0xbe, 0x0e, 0x6e, 0xdb, 0xe5, 0x60, 0xdc, 0xd7
	/* entry_count */
	.word	3
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module12_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.AndroidX.SavedState */
	.xword	.L.map_aname.12
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 45e350cd-67a5-458a-8dc6-f2708b7d90d2 */
	.byte	0xcd, 0x50, 0xe3, 0x45, 0xa5, 0x67, 0x8a, 0x45, 0x8d, 0xc6, 0xf2, 0x70, 0x8b, 0x7d, 0x90, 0xd2
	/* entry_count */
	.word	5
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module13_managed_to_java
	/* duplicate_map */
	.xword	module13_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Loader */
	.xword	.L.map_aname.13
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 2393e2cf-a855-4b84-b09a-ca629200891d */
	.byte	0xcf, 0xe2, 0x93, 0x23, 0x55, 0xa8, 0x84, 0x4b, 0xb0, 0x9a, 0xca, 0x62, 0x92, 0x00, 0x89, 0x1d
	/* entry_count */
	.word	9
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module14_managed_to_java
	/* duplicate_map */
	.xword	module14_managed_to_java_duplicates
	/* assembly_name: Xamarin.GooglePlayServices.Vision.Common */
	.xword	.L.map_aname.14
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 1fe0f2d1-97a7-4e89-9057-41f209c8b421 */
	.byte	0xd1, 0xf2, 0xe0, 0x1f, 0xa7, 0x97, 0x89, 0x4e, 0x90, 0x57, 0x41, 0xf2, 0x09, 0xc8, 0xb4, 0x21
	/* entry_count */
	.word	2
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module15_managed_to_java
	/* duplicate_map */
	.xword	module15_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Lifecycle.LiveData.Core */
	.xword	.L.map_aname.15
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 84e908d8-ef9c-482a-9e69-d5f1f375cd37 */
	.byte	0xd8, 0x08, 0xe9, 0x84, 0x9c, 0xef, 0x2a, 0x48, 0x9e, 0x69, 0xd5, 0xf1, 0xf3, 0x75, 0xcd, 0x37
	/* entry_count */
	.word	10
	/* duplicate_count */
	.word	2
	/* map */
	.xword	module16_managed_to_java
	/* duplicate_map */
	.xword	module16_managed_to_java_duplicates
	/* assembly_name: Xamarin.Google.Android.Material */
	.xword	.L.map_aname.16
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 22ab85d9-c40c-4739-b6fe-c7ac6cfd022e */
	.byte	0xd9, 0x85, 0xab, 0x22, 0x0c, 0xc4, 0x39, 0x47, 0xb6, 0xfe, 0xc7, 0xac, 0x6c, 0xfd, 0x02, 0x2e
	/* entry_count */
	.word	1
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module17_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.Google.Guava.ListenableFuture */
	.xword	.L.map_aname.17
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 370644e8-415c-45c0-99db-ef235ef8f8e5 */
	.byte	0xe8, 0x44, 0x06, 0x37, 0x5c, 0x41, 0xc0, 0x45, 0x99, 0xdb, 0xef, 0x23, 0x5e, 0xf8, 0xf8, 0xe5
	/* entry_count */
	.word	5
	/* duplicate_count */
	.word	0
	/* map */
	.xword	module18_managed_to_java
	/* duplicate_map */
	.xword	0
	/* assembly_name: Xamarin.AndroidX.Lifecycle.ViewModel */
	.xword	.L.map_aname.18
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 881ed6ea-01f5-4e6a-a506-f471ee0a009c */
	.byte	0xea, 0xd6, 0x1e, 0x88, 0xf5, 0x01, 0x6a, 0x4e, 0xa5, 0x06, 0xf4, 0x71, 0xee, 0x0a, 0x00, 0x9c
	/* entry_count */
	.word	4
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module19_managed_to_java
	/* duplicate_map */
	.xword	module19_managed_to_java_duplicates
	/* assembly_name: Xamarin.AndroidX.Lifecycle.Common */
	.xword	.L.map_aname.19
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	/* module_uuid: 8e876af2-a526-46fa-83a7-1c2d0e6e3f1e */
	.byte	0xf2, 0x6a, 0x87, 0x8e, 0x26, 0xa5, 0xfa, 0x46, 0x83, 0xa7, 0x1c, 0x2d, 0x0e, 0x6e, 0x3f, 0x1e
	/* entry_count */
	.word	2
	/* duplicate_count */
	.word	1
	/* map */
	.xword	module20_managed_to_java
	/* duplicate_map */
	.xword	module20_managed_to_java_duplicates
	/* assembly_name: Xamarin.GooglePlayServices.Basement */
	.xword	.L.map_aname.20
	/* image */
	.xword	0
	/* java_name_width */
	.word	0
	/* java_map */
	.zero	4
	.xword	0

	.size	map_modules, 1512
/* Managed to Java map: END */

/* Java to managed map: START */
	.section	.rodata.map_java,"a",@progbits
	.type	map_java, @object
	.p2align	2
	.global	map_java
map_java:
	/* #0 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554723
	/* java_name */
	.ascii	"android/animation/Animator"
	.zero	66

	/* #1 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554725
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorListener"
	.zero	49

	/* #2 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554727
	/* java_name */
	.ascii	"android/animation/Animator$AnimatorPauseListener"
	.zero	44

	/* #3 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554729
	/* java_name */
	.ascii	"android/animation/AnimatorListenerAdapter"
	.zero	51

	/* #4 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554732
	/* java_name */
	.ascii	"android/animation/TimeInterpolator"
	.zero	58

	/* #5 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554734
	/* java_name */
	.ascii	"android/app/Activity"
	.zero	72

	/* #6 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554735
	/* java_name */
	.ascii	"android/app/Application"
	.zero	69

	/* #7 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554736
	/* java_name */
	.ascii	"android/app/Dialog"
	.zero	74

	/* #8 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554741
	/* java_name */
	.ascii	"android/app/PendingIntent"
	.zero	67

	/* #9 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554750
	/* java_name */
	.ascii	"android/content/ComponentCallbacks"
	.zero	58

	/* #10 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554752
	/* java_name */
	.ascii	"android/content/ComponentCallbacks2"
	.zero	57

	/* #11 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554745
	/* java_name */
	.ascii	"android/content/ComponentName"
	.zero	63

	/* #12 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554743
	/* java_name */
	.ascii	"android/content/Context"
	.zero	69

	/* #13 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554747
	/* java_name */
	.ascii	"android/content/ContextWrapper"
	.zero	62

	/* #14 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554754
	/* java_name */
	.ascii	"android/content/DialogInterface"
	.zero	61

	/* #15 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554744
	/* java_name */
	.ascii	"android/content/Intent"
	.zero	70

	/* #16 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554755
	/* java_name */
	.ascii	"android/content/IntentSender"
	.zero	64

	/* #17 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554761
	/* java_name */
	.ascii	"android/content/SharedPreferences"
	.zero	59

	/* #18 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554757
	/* java_name */
	.ascii	"android/content/SharedPreferences$Editor"
	.zero	52

	/* #19 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554759
	/* java_name */
	.ascii	"android/content/SharedPreferences$OnSharedPreferenceChangeListener"
	.zero	26

	/* #20 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554764
	/* java_name */
	.ascii	"android/content/pm/PackageInfo"
	.zero	62

	/* #21 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554766
	/* java_name */
	.ascii	"android/content/pm/PackageManager"
	.zero	59

	/* #22 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554770
	/* java_name */
	.ascii	"android/content/res/ColorStateList"
	.zero	58

	/* #23 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554771
	/* java_name */
	.ascii	"android/content/res/Configuration"
	.zero	59

	/* #24 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554772
	/* java_name */
	.ascii	"android/content/res/Resources"
	.zero	63

	/* #25 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554574
	/* java_name */
	.ascii	"android/database/DataSetObserver"
	.zero	60

	/* #26 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554708
	/* java_name */
	.ascii	"android/graphics/Bitmap"
	.zero	69

	/* #27 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554709
	/* java_name */
	.ascii	"android/graphics/Canvas"
	.zero	69

	/* #28 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554710
	/* java_name */
	.ascii	"android/graphics/ColorFilter"
	.zero	64

	/* #29 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554712
	/* java_name */
	.ascii	"android/graphics/Matrix"
	.zero	69

	/* #30 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554713
	/* java_name */
	.ascii	"android/graphics/Paint"
	.zero	70

	/* #31 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554714
	/* java_name */
	.ascii	"android/graphics/Point"
	.zero	70

	/* #32 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554715
	/* java_name */
	.ascii	"android/graphics/PorterDuff"
	.zero	65

	/* #33 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554716
	/* java_name */
	.ascii	"android/graphics/PorterDuff$Mode"
	.zero	60

	/* #34 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554717
	/* java_name */
	.ascii	"android/graphics/Rect"
	.zero	71

	/* #35 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554718
	/* java_name */
	.ascii	"android/graphics/RectF"
	.zero	70

	/* #36 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554719
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable"
	.zero	58

	/* #37 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554721
	/* java_name */
	.ascii	"android/graphics/drawable/Drawable$Callback"
	.zero	49

	/* #38 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554703
	/* java_name */
	.ascii	"android/media/Image"
	.zero	73

	/* #39 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554704
	/* java_name */
	.ascii	"android/media/Image$Plane"
	.zero	67

	/* #40 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554701
	/* java_name */
	.ascii	"android/net/Uri"
	.zero	77

	/* #41 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554689
	/* java_name */
	.ascii	"android/os/BaseBundle"
	.zero	71

	/* #42 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554690
	/* java_name */
	.ascii	"android/os/Build"
	.zero	76

	/* #43 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554691
	/* java_name */
	.ascii	"android/os/Build$VERSION"
	.zero	68

	/* #44 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554693
	/* java_name */
	.ascii	"android/os/Bundle"
	.zero	75

	/* #45 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554688
	/* java_name */
	.ascii	"android/os/Handler"
	.zero	74

	/* #46 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554698
	/* java_name */
	.ascii	"android/os/Looper"
	.zero	75

	/* #47 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554699
	/* java_name */
	.ascii	"android/os/Parcel"
	.zero	75

	/* #48 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554697
	/* java_name */
	.ascii	"android/os/Parcelable"
	.zero	71

	/* #49 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554695
	/* java_name */
	.ascii	"android/os/Parcelable$Creator"
	.zero	63

	/* #50 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554687
	/* java_name */
	.ascii	"android/preference/PreferenceManager"
	.zero	56

	/* #51 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554818
	/* java_name */
	.ascii	"android/runtime/JavaProxyThrowable"
	.zero	58

	/* #52 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554685
	/* java_name */
	.ascii	"android/util/AttributeSet"
	.zero	67

	/* #53 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554683
	/* java_name */
	.ascii	"android/util/DisplayMetrics"
	.zero	65

	/* #54 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554686
	/* java_name */
	.ascii	"android/util/SparseArray"
	.zero	68

	/* #55 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554612
	/* java_name */
	.ascii	"android/view/ActionMode"
	.zero	69

	/* #56 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554614
	/* java_name */
	.ascii	"android/view/ActionMode$Callback"
	.zero	60

	/* #57 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554617
	/* java_name */
	.ascii	"android/view/ActionProvider"
	.zero	65

	/* #58 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554626
	/* java_name */
	.ascii	"android/view/ContextMenu"
	.zero	68

	/* #59 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554624
	/* java_name */
	.ascii	"android/view/ContextMenu$ContextMenuInfo"
	.zero	52

	/* #60 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554619
	/* java_name */
	.ascii	"android/view/ContextThemeWrapper"
	.zero	60

	/* #61 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554620
	/* java_name */
	.ascii	"android/view/Display"
	.zero	72

	/* #62 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554621
	/* java_name */
	.ascii	"android/view/DragEvent"
	.zero	70

	/* #63 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554635
	/* java_name */
	.ascii	"android/view/InputEvent"
	.zero	69

	/* #64 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554597
	/* java_name */
	.ascii	"android/view/KeyEvent"
	.zero	71

	/* #65 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554599
	/* java_name */
	.ascii	"android/view/KeyEvent$Callback"
	.zero	62

	/* #66 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554600
	/* java_name */
	.ascii	"android/view/LayoutInflater"
	.zero	65

	/* #67 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554602
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory"
	.zero	57

	/* #68 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554604
	/* java_name */
	.ascii	"android/view/LayoutInflater$Factory2"
	.zero	56

	/* #69 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554628
	/* java_name */
	.ascii	"android/view/Menu"
	.zero	75

	/* #70 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554654
	/* java_name */
	.ascii	"android/view/MenuInflater"
	.zero	67

	/* #71 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554634
	/* java_name */
	.ascii	"android/view/MenuItem"
	.zero	71

	/* #72 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554630
	/* java_name */
	.ascii	"android/view/MenuItem$OnActionExpandListener"
	.zero	48

	/* #73 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554632
	/* java_name */
	.ascii	"android/view/MenuItem$OnMenuItemClickListener"
	.zero	47

	/* #74 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554605
	/* java_name */
	.ascii	"android/view/MotionEvent"
	.zero	68

	/* #75 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554657
	/* java_name */
	.ascii	"android/view/SearchEvent"
	.zero	68

	/* #76 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554638
	/* java_name */
	.ascii	"android/view/SubMenu"
	.zero	72

	/* #77 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554660
	/* java_name */
	.ascii	"android/view/Surface"
	.zero	72

	/* #78 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554642
	/* java_name */
	.ascii	"android/view/SurfaceHolder"
	.zero	66

	/* #79 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554640
	/* java_name */
	.ascii	"android/view/SurfaceHolder$Callback"
	.zero	57

	/* #80 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554662
	/* java_name */
	.ascii	"android/view/SurfaceView"
	.zero	68

	/* #81 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554589
	/* java_name */
	.ascii	"android/view/View"
	.zero	75

	/* #82 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554591
	/* java_name */
	.ascii	"android/view/View$OnClickListener"
	.zero	59

	/* #83 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554594
	/* java_name */
	.ascii	"android/view/View$OnCreateContextMenuListener"
	.zero	47

	/* #84 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554665
	/* java_name */
	.ascii	"android/view/ViewGroup"
	.zero	70

	/* #85 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554666
	/* java_name */
	.ascii	"android/view/ViewGroup$LayoutParams"
	.zero	57

	/* #86 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554667
	/* java_name */
	.ascii	"android/view/ViewGroup$MarginLayoutParams"
	.zero	51

	/* #87 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554644
	/* java_name */
	.ascii	"android/view/ViewManager"
	.zero	68

	/* #88 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554646
	/* java_name */
	.ascii	"android/view/ViewParent"
	.zero	69

	/* #89 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554669
	/* java_name */
	.ascii	"android/view/ViewPropertyAnimator"
	.zero	59

	/* #90 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554606
	/* java_name */
	.ascii	"android/view/ViewTreeObserver"
	.zero	63

	/* #91 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554608
	/* java_name */
	.ascii	"android/view/ViewTreeObserver$OnPreDrawListener"
	.zero	45

	/* #92 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554609
	/* java_name */
	.ascii	"android/view/Window"
	.zero	73

	/* #93 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554611
	/* java_name */
	.ascii	"android/view/Window$Callback"
	.zero	64

	/* #94 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554671
	/* java_name */
	.ascii	"android/view/WindowInsets"
	.zero	67

	/* #95 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554649
	/* java_name */
	.ascii	"android/view/WindowManager"
	.zero	66

	/* #96 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554647
	/* java_name */
	.ascii	"android/view/WindowManager$LayoutParams"
	.zero	53

	/* #97 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554676
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEvent"
	.zero	47

	/* #98 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554682
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityEventSource"
	.zero	41

	/* #99 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554677
	/* java_name */
	.ascii	"android/view/accessibility/AccessibilityRecord"
	.zero	46

	/* #100 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554672
	/* java_name */
	.ascii	"android/view/animation/Animation"
	.zero	60

	/* #101 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554675
	/* java_name */
	.ascii	"android/view/animation/Interpolator"
	.zero	57

	/* #102 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554586
	/* java_name */
	.ascii	"android/widget/Adapter"
	.zero	70

	/* #103 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554576
	/* java_name */
	.ascii	"android/widget/AdapterView"
	.zero	66

	/* #104 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554578
	/* java_name */
	.ascii	"android/widget/AdapterView$OnItemSelectedListener"
	.zero	43

	/* #105 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554581
	/* java_name */
	.ascii	"android/widget/Button"
	.zero	71

	/* #106 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554582
	/* java_name */
	.ascii	"android/widget/EditText"
	.zero	69

	/* #107 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554583
	/* java_name */
	.ascii	"android/widget/FrameLayout"
	.zero	66

	/* #108 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554584
	/* java_name */
	.ascii	"android/widget/HorizontalScrollView"
	.zero	57

	/* #109 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554588
	/* java_name */
	.ascii	"android/widget/SpinnerAdapter"
	.zero	63

	/* #110 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554579
	/* java_name */
	.ascii	"android/widget/TextView"
	.zero	69

	/* #111 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"androidx/activity/ComponentActivity"
	.zero	57

	/* #112 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"androidx/activity/OnBackPressedCallback"
	.zero	53

	/* #113 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"androidx/activity/OnBackPressedDispatcher"
	.zero	51

	/* #114 */
	/* module_index */
	.word	11
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"androidx/activity/OnBackPressedDispatcherOwner"
	.zero	46

	/* #115 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar"
	.zero	60

	/* #116 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554476
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar$LayoutParams"
	.zero	47

	/* #117 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554478
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar$OnMenuVisibilityListener"
	.zero	35

	/* #118 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554482
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar$OnNavigationListener"
	.zero	39

	/* #119 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554483
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar$Tab"
	.zero	56

	/* #120 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554486
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBar$TabListener"
	.zero	48

	/* #121 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554490
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBarDrawerToggle"
	.zero	48

	/* #122 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554492
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBarDrawerToggle$Delegate"
	.zero	39

	/* #123 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554494
	/* java_name */
	.ascii	"androidx/appcompat/app/ActionBarDrawerToggle$DelegateProvider"
	.zero	31

	/* #124 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554495
	/* java_name */
	.ascii	"androidx/appcompat/app/AppCompatActivity"
	.zero	52

	/* #125 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554499
	/* java_name */
	.ascii	"androidx/appcompat/app/AppCompatCallback"
	.zero	52

	/* #126 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554496
	/* java_name */
	.ascii	"androidx/appcompat/app/AppCompatDelegate"
	.zero	52

	/* #127 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"androidx/appcompat/graphics/drawable/DrawerArrowDrawable"
	.zero	36

	/* #128 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554513
	/* java_name */
	.ascii	"androidx/appcompat/view/ActionMode"
	.zero	58

	/* #129 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554515
	/* java_name */
	.ascii	"androidx/appcompat/view/ActionMode$Callback"
	.zero	49

	/* #130 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554517
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuBuilder"
	.zero	52

	/* #131 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554519
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuBuilder$Callback"
	.zero	43

	/* #132 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554526
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuItemImpl"
	.zero	51

	/* #133 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554523
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuPresenter"
	.zero	50

	/* #134 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554521
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuPresenter$Callback"
	.zero	41

	/* #135 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554525
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/MenuView"
	.zero	55

	/* #136 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554527
	/* java_name */
	.ascii	"androidx/appcompat/view/menu/SubMenuBuilder"
	.zero	49

	/* #137 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554510
	/* java_name */
	.ascii	"androidx/appcompat/widget/DecorToolbar"
	.zero	54

	/* #138 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554511
	/* java_name */
	.ascii	"androidx/appcompat/widget/ScrollingTabContainerView"
	.zero	41

	/* #139 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554512
	/* java_name */
	.ascii	"androidx/appcompat/widget/ScrollingTabContainerView$VisibilityAnimListener"
	.zero	18

	/* #140 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554500
	/* java_name */
	.ascii	"androidx/appcompat/widget/Toolbar"
	.zero	59

	/* #141 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554504
	/* java_name */
	.ascii	"androidx/appcompat/widget/Toolbar$OnMenuItemClickListener"
	.zero	35

	/* #142 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554501
	/* java_name */
	.ascii	"androidx/appcompat/widget/Toolbar_NavigationOnClickEventDispatcher"
	.zero	26

	/* #143 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554472
	/* java_name */
	.ascii	"androidx/coordinatorlayout/widget/CoordinatorLayout"
	.zero	41

	/* #144 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554473
	/* java_name */
	.ascii	"androidx/coordinatorlayout/widget/CoordinatorLayout$Behavior"
	.zero	32

	/* #145 */
	/* module_index */
	.word	0
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"androidx/coordinatorlayout/widget/CoordinatorLayout$LayoutParams"
	.zero	28

	/* #146 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554514
	/* java_name */
	.ascii	"androidx/core/app/ActivityCompat"
	.zero	60

	/* #147 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554516
	/* java_name */
	.ascii	"androidx/core/app/ActivityCompat$OnRequestPermissionsResultCallback"
	.zero	25

	/* #148 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554518
	/* java_name */
	.ascii	"androidx/core/app/ActivityCompat$PermissionCompatDelegate"
	.zero	35

	/* #149 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554520
	/* java_name */
	.ascii	"androidx/core/app/ActivityCompat$RequestPermissionsRequestCodeValidator"
	.zero	21

	/* #150 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554521
	/* java_name */
	.ascii	"androidx/core/app/ComponentActivity"
	.zero	57

	/* #151 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554522
	/* java_name */
	.ascii	"androidx/core/app/ComponentActivity$ExtraData"
	.zero	47

	/* #152 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554523
	/* java_name */
	.ascii	"androidx/core/app/SharedElementCallback"
	.zero	53

	/* #153 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554525
	/* java_name */
	.ascii	"androidx/core/app/SharedElementCallback$OnSharedElementsReadyListener"
	.zero	23

	/* #154 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554527
	/* java_name */
	.ascii	"androidx/core/app/TaskStackBuilder"
	.zero	58

	/* #155 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554529
	/* java_name */
	.ascii	"androidx/core/app/TaskStackBuilder$SupportParentable"
	.zero	40

	/* #156 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554513
	/* java_name */
	.ascii	"androidx/core/content/ContextCompat"
	.zero	57

	/* #157 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554512
	/* java_name */
	.ascii	"androidx/core/graphics/Insets"
	.zero	63

	/* #158 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554509
	/* java_name */
	.ascii	"androidx/core/internal/view/SupportMenu"
	.zero	53

	/* #159 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554511
	/* java_name */
	.ascii	"androidx/core/internal/view/SupportMenuItem"
	.zero	49

	/* #160 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554477
	/* java_name */
	.ascii	"androidx/core/view/ActionProvider"
	.zero	59

	/* #161 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"androidx/core/view/ActionProvider$SubUiVisibilityListener"
	.zero	35

	/* #162 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554483
	/* java_name */
	.ascii	"androidx/core/view/ActionProvider$VisibilityListener"
	.zero	40

	/* #163 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554491
	/* java_name */
	.ascii	"androidx/core/view/DisplayCutoutCompat"
	.zero	54

	/* #164 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554492
	/* java_name */
	.ascii	"androidx/core/view/DragAndDropPermissionsCompat"
	.zero	45

	/* #165 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554503
	/* java_name */
	.ascii	"androidx/core/view/KeyEventDispatcher"
	.zero	55

	/* #166 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554505
	/* java_name */
	.ascii	"androidx/core/view/KeyEventDispatcher$Component"
	.zero	45

	/* #167 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554494
	/* java_name */
	.ascii	"androidx/core/view/NestedScrollingParent"
	.zero	52

	/* #168 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554496
	/* java_name */
	.ascii	"androidx/core/view/NestedScrollingParent2"
	.zero	51

	/* #169 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554498
	/* java_name */
	.ascii	"androidx/core/view/NestedScrollingParent3"
	.zero	51

	/* #170 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554506
	/* java_name */
	.ascii	"androidx/core/view/ViewPropertyAnimatorCompat"
	.zero	47

	/* #171 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554500
	/* java_name */
	.ascii	"androidx/core/view/ViewPropertyAnimatorListener"
	.zero	45

	/* #172 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554502
	/* java_name */
	.ascii	"androidx/core/view/ViewPropertyAnimatorUpdateListener"
	.zero	39

	/* #173 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554507
	/* java_name */
	.ascii	"androidx/core/view/WindowInsetsCompat"
	.zero	55

	/* #174 */
	/* module_index */
	.word	2
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"androidx/customview/widget/Openable"
	.zero	57

	/* #175 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	33554455
	/* java_name */
	.ascii	"androidx/drawerlayout/widget/DrawerLayout"
	.zero	51

	/* #176 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"androidx/drawerlayout/widget/DrawerLayout$DrawerListener"
	.zero	36

	/* #177 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554469
	/* java_name */
	.ascii	"androidx/fragment/app/Fragment"
	.zero	62

	/* #178 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554470
	/* java_name */
	.ascii	"androidx/fragment/app/Fragment$SavedState"
	.zero	51

	/* #179 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554468
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentActivity"
	.zero	54

	/* #180 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554471
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentFactory"
	.zero	55

	/* #181 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554472
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentManager"
	.zero	55

	/* #182 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554474
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentManager$BackStackEntry"
	.zero	40

	/* #183 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554475
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentManager$FragmentLifecycleCallbacks"
	.zero	28

	/* #184 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554478
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentManager$OnBackStackChangedListener"
	.zero	28

	/* #185 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554483
	/* java_name */
	.ascii	"androidx/fragment/app/FragmentTransaction"
	.zero	51

	/* #186 */
	/* module_index */
	.word	18
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"androidx/lifecycle/HasDefaultViewModelProviderFactory"
	.zero	39

	/* #187 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"androidx/lifecycle/Lifecycle"
	.zero	64

	/* #188 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"androidx/lifecycle/Lifecycle$State"
	.zero	58

	/* #189 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"androidx/lifecycle/LifecycleObserver"
	.zero	56

	/* #190 */
	/* module_index */
	.word	19
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"androidx/lifecycle/LifecycleOwner"
	.zero	59

	/* #191 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"androidx/lifecycle/LiveData"
	.zero	65

	/* #192 */
	/* module_index */
	.word	15
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"androidx/lifecycle/Observer"
	.zero	65

	/* #193 */
	/* module_index */
	.word	18
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"androidx/lifecycle/ViewModelProvider"
	.zero	56

	/* #194 */
	/* module_index */
	.word	18
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"androidx/lifecycle/ViewModelProvider$Factory"
	.zero	48

	/* #195 */
	/* module_index */
	.word	18
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"androidx/lifecycle/ViewModelStore"
	.zero	59

	/* #196 */
	/* module_index */
	.word	18
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"androidx/lifecycle/ViewModelStoreOwner"
	.zero	54

	/* #197 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"androidx/loader/app/LoaderManager"
	.zero	59

	/* #198 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554455
	/* java_name */
	.ascii	"androidx/loader/app/LoaderManager$LoaderCallbacks"
	.zero	43

	/* #199 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"androidx/loader/content/Loader"
	.zero	62

	/* #200 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"androidx/loader/content/Loader$OnLoadCanceledListener"
	.zero	39

	/* #201 */
	/* module_index */
	.word	13
	/* type_token_id */
	.word	33554452
	/* java_name */
	.ascii	"androidx/loader/content/Loader$OnLoadCompleteListener"
	.zero	39

	/* #202 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"androidx/savedstate/SavedStateRegistry"
	.zero	54

	/* #203 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"androidx/savedstate/SavedStateRegistry$SavedStateProvider"
	.zero	35

	/* #204 */
	/* module_index */
	.word	12
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"androidx/savedstate/SavedStateRegistryOwner"
	.zero	49

	/* #205 */
	/* module_index */
	.word	1
	/* type_token_id */
	.word	33554435
	/* java_name */
	.ascii	"com/google/android/gms/common/images/Size"
	.zero	51

	/* #206 */
	/* module_index */
	.word	20
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"com/google/android/gms/common/internal/safeparcel/AbstractSafeParcelable"
	.zero	20

	/* #207 */
	/* module_index */
	.word	20
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"com/google/android/gms/common/internal/safeparcel/SafeParcelable"
	.zero	28

	/* #208 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"com/google/android/gms/tasks/CancellationToken"
	.zero	46

	/* #209 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"com/google/android/gms/tasks/Continuation"
	.zero	51

	/* #210 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554449
	/* java_name */
	.ascii	"com/google/android/gms/tasks/OnCanceledListener"
	.zero	45

	/* #211 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"com/google/android/gms/tasks/OnCompleteListener"
	.zero	45

	/* #212 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"com/google/android/gms/tasks/OnFailureListener"
	.zero	46

	/* #213 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554455
	/* java_name */
	.ascii	"com/google/android/gms/tasks/OnSuccessListener"
	.zero	46

	/* #214 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"com/google/android/gms/tasks/OnTokenCanceledListener"
	.zero	40

	/* #215 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"com/google/android/gms/tasks/SuccessContinuation"
	.zero	44

	/* #216 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"com/google/android/gms/tasks/Task"
	.zero	59

	/* #217 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	33554443
	/* java_name */
	.ascii	"com/google/android/gms/tasks/TaskCompletionSource"
	.zero	43

	/* #218 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"com/google/android/gms/vision/CameraSource"
	.zero	50

	/* #219 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"com/google/android/gms/vision/CameraSource$Builder"
	.zero	42

	/* #220 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"com/google/android/gms/vision/CameraSource$PictureCallback"
	.zero	34

	/* #221 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554455
	/* java_name */
	.ascii	"com/google/android/gms/vision/CameraSource$ShutterCallback"
	.zero	34

	/* #222 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554456
	/* java_name */
	.ascii	"com/google/android/gms/vision/Detector"
	.zero	54

	/* #223 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"com/google/android/gms/vision/Detector$Detections"
	.zero	43

	/* #224 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"com/google/android/gms/vision/Detector$Processor"
	.zero	44

	/* #225 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"com/google/android/gms/vision/Frame"
	.zero	57

	/* #226 */
	/* module_index */
	.word	14
	/* type_token_id */
	.word	33554462
	/* java_name */
	.ascii	"com/google/android/gms/vision/Frame$Metadata"
	.zero	48

	/* #227 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554438
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode"
	.zero	47

	/* #228 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554439
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$Address"
	.zero	39

	/* #229 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554440
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$CalendarDateTime"
	.zero	30

	/* #230 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554441
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$CalendarEvent"
	.zero	33

	/* #231 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554442
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$ContactInfo"
	.zero	35

	/* #232 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554443
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$DriverLicense"
	.zero	33

	/* #233 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554444
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$Email"
	.zero	41

	/* #234 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554445
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$GeoPoint"
	.zero	38

	/* #235 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554446
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$PersonName"
	.zero	36

	/* #236 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554447
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$Phone"
	.zero	41

	/* #237 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554448
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$Sms"
	.zero	43

	/* #238 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554449
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$UrlBookmark"
	.zero	35

	/* #239 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554450
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/Barcode$WiFi"
	.zero	42

	/* #240 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/BarcodeDetector"
	.zero	39

	/* #241 */
	/* module_index */
	.word	7
	/* type_token_id */
	.word	33554454
	/* java_name */
	.ascii	"com/google/android/gms/vision/barcode/BarcodeDetector$Builder"
	.zero	31

	/* #242 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554451
	/* java_name */
	.ascii	"com/google/android/material/behavior/SwipeDismissBehavior"
	.zero	35

	/* #243 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554453
	/* java_name */
	.ascii	"com/google/android/material/behavior/SwipeDismissBehavior$OnDismissListener"
	.zero	17

	/* #244 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554460
	/* java_name */
	.ascii	"com/google/android/material/snackbar/BaseTransientBottomBar"
	.zero	33

	/* #245 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554461
	/* java_name */
	.ascii	"com/google/android/material/snackbar/BaseTransientBottomBar$BaseCallback"
	.zero	20

	/* #246 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554463
	/* java_name */
	.ascii	"com/google/android/material/snackbar/BaseTransientBottomBar$Behavior"
	.zero	24

	/* #247 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554466
	/* java_name */
	.ascii	"com/google/android/material/snackbar/ContentViewCallback"
	.zero	36

	/* #248 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554457
	/* java_name */
	.ascii	"com/google/android/material/snackbar/Snackbar"
	.zero	47

	/* #249 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554459
	/* java_name */
	.ascii	"com/google/android/material/snackbar/Snackbar$Callback"
	.zero	38

	/* #250 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554458
	/* java_name */
	.ascii	"com/google/android/material/snackbar/Snackbar_SnackbarActionClickImplementor"
	.zero	16

	/* #251 */
	/* module_index */
	.word	17
	/* type_token_id */
	.word	33554436
	/* java_name */
	.ascii	"com/google/common/util/concurrent/ListenableFuture"
	.zero	42

	/* #252 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554434
	/* java_name */
	.ascii	"crc644343627f3a355449/CameraATY"
	.zero	61

	/* #253 */
	/* module_index */
	.word	8
	/* type_token_id */
	.word	33554437
	/* java_name */
	.ascii	"crc644343627f3a355449/MainActivity"
	.zero	58

	/* #254 */
	/* module_index */
	.word	10
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"crc6495d4f5d63cc5c882/AwaitableTaskCompleteListener_1"
	.zero	39

	/* #255 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554974
	/* java_name */
	.ascii	"java/io/Closeable"
	.zero	75

	/* #256 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554970
	/* java_name */
	.ascii	"java/io/File"
	.zero	80

	/* #257 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554971
	/* java_name */
	.ascii	"java/io/FileDescriptor"
	.zero	70

	/* #258 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554972
	/* java_name */
	.ascii	"java/io/FileInputStream"
	.zero	69

	/* #259 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554976
	/* java_name */
	.ascii	"java/io/Flushable"
	.zero	75

	/* #260 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554980
	/* java_name */
	.ascii	"java/io/IOException"
	.zero	73

	/* #261 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554977
	/* java_name */
	.ascii	"java/io/InputStream"
	.zero	73

	/* #262 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554979
	/* java_name */
	.ascii	"java/io/InterruptedIOException"
	.zero	62

	/* #263 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554983
	/* java_name */
	.ascii	"java/io/OutputStream"
	.zero	72

	/* #264 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554985
	/* java_name */
	.ascii	"java/io/PrintWriter"
	.zero	73

	/* #265 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554982
	/* java_name */
	.ascii	"java/io/Serializable"
	.zero	72

	/* #266 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554986
	/* java_name */
	.ascii	"java/io/StringWriter"
	.zero	72

	/* #267 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554987
	/* java_name */
	.ascii	"java/io/Writer"
	.zero	78

	/* #268 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554936
	/* java_name */
	.ascii	"java/lang/Appendable"
	.zero	72

	/* #269 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554938
	/* java_name */
	.ascii	"java/lang/AutoCloseable"
	.zero	69

	/* #270 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554910
	/* java_name */
	.ascii	"java/lang/Boolean"
	.zero	75

	/* #271 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554911
	/* java_name */
	.ascii	"java/lang/Byte"
	.zero	78

	/* #272 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554939
	/* java_name */
	.ascii	"java/lang/CharSequence"
	.zero	70

	/* #273 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554912
	/* java_name */
	.ascii	"java/lang/Character"
	.zero	73

	/* #274 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554913
	/* java_name */
	.ascii	"java/lang/Class"
	.zero	77

	/* #275 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554929
	/* java_name */
	.ascii	"java/lang/ClassCastException"
	.zero	64

	/* #276 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554930
	/* java_name */
	.ascii	"java/lang/ClassLoader"
	.zero	71

	/* #277 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554914
	/* java_name */
	.ascii	"java/lang/ClassNotFoundException"
	.zero	60

	/* #278 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554942
	/* java_name */
	.ascii	"java/lang/Cloneable"
	.zero	73

	/* #279 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554944
	/* java_name */
	.ascii	"java/lang/Comparable"
	.zero	72

	/* #280 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554915
	/* java_name */
	.ascii	"java/lang/Double"
	.zero	76

	/* #281 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554932
	/* java_name */
	.ascii	"java/lang/Enum"
	.zero	78

	/* #282 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554934
	/* java_name */
	.ascii	"java/lang/Error"
	.zero	77

	/* #283 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554916
	/* java_name */
	.ascii	"java/lang/Exception"
	.zero	73

	/* #284 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554917
	/* java_name */
	.ascii	"java/lang/Float"
	.zero	77

	/* #285 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554947
	/* java_name */
	.ascii	"java/lang/IllegalArgumentException"
	.zero	58

	/* #286 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554948
	/* java_name */
	.ascii	"java/lang/IllegalStateException"
	.zero	61

	/* #287 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554949
	/* java_name */
	.ascii	"java/lang/IndexOutOfBoundsException"
	.zero	57

	/* #288 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554919
	/* java_name */
	.ascii	"java/lang/Integer"
	.zero	75

	/* #289 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554946
	/* java_name */
	.ascii	"java/lang/Iterable"
	.zero	74

	/* #290 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554952
	/* java_name */
	.ascii	"java/lang/LinkageError"
	.zero	70

	/* #291 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554920
	/* java_name */
	.ascii	"java/lang/Long"
	.zero	78

	/* #292 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554953
	/* java_name */
	.ascii	"java/lang/NoClassDefFoundError"
	.zero	62

	/* #293 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554954
	/* java_name */
	.ascii	"java/lang/NullPointerException"
	.zero	62

	/* #294 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554955
	/* java_name */
	.ascii	"java/lang/Number"
	.zero	76

	/* #295 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554921
	/* java_name */
	.ascii	"java/lang/Object"
	.zero	76

	/* #296 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554957
	/* java_name */
	.ascii	"java/lang/ReflectiveOperationException"
	.zero	54

	/* #297 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554951
	/* java_name */
	.ascii	"java/lang/Runnable"
	.zero	74

	/* #298 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554922
	/* java_name */
	.ascii	"java/lang/RuntimeException"
	.zero	66

	/* #299 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554958
	/* java_name */
	.ascii	"java/lang/SecurityException"
	.zero	65

	/* #300 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554923
	/* java_name */
	.ascii	"java/lang/Short"
	.zero	77

	/* #301 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554924
	/* java_name */
	.ascii	"java/lang/String"
	.zero	76

	/* #302 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554926
	/* java_name */
	.ascii	"java/lang/Thread"
	.zero	76

	/* #303 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554928
	/* java_name */
	.ascii	"java/lang/Throwable"
	.zero	73

	/* #304 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554959
	/* java_name */
	.ascii	"java/lang/UnsupportedOperationException"
	.zero	53

	/* #305 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554961
	/* java_name */
	.ascii	"java/lang/annotation/Annotation"
	.zero	61

	/* #306 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554963
	/* java_name */
	.ascii	"java/lang/reflect/AnnotatedElement"
	.zero	58

	/* #307 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554965
	/* java_name */
	.ascii	"java/lang/reflect/GenericDeclaration"
	.zero	56

	/* #308 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554967
	/* java_name */
	.ascii	"java/lang/reflect/Type"
	.zero	70

	/* #309 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554969
	/* java_name */
	.ascii	"java/lang/reflect/TypeVariable"
	.zero	62

	/* #310 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554842
	/* java_name */
	.ascii	"java/net/ConnectException"
	.zero	67

	/* #311 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554844
	/* java_name */
	.ascii	"java/net/HttpURLConnection"
	.zero	66

	/* #312 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554846
	/* java_name */
	.ascii	"java/net/InetSocketAddress"
	.zero	66

	/* #313 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554847
	/* java_name */
	.ascii	"java/net/ProtocolException"
	.zero	66

	/* #314 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554848
	/* java_name */
	.ascii	"java/net/Proxy"
	.zero	78

	/* #315 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554849
	/* java_name */
	.ascii	"java/net/Proxy$Type"
	.zero	73

	/* #316 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554850
	/* java_name */
	.ascii	"java/net/ProxySelector"
	.zero	70

	/* #317 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554852
	/* java_name */
	.ascii	"java/net/SocketAddress"
	.zero	70

	/* #318 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554854
	/* java_name */
	.ascii	"java/net/SocketException"
	.zero	68

	/* #319 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554855
	/* java_name */
	.ascii	"java/net/SocketTimeoutException"
	.zero	61

	/* #320 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554857
	/* java_name */
	.ascii	"java/net/URI"
	.zero	80

	/* #321 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554858
	/* java_name */
	.ascii	"java/net/URL"
	.zero	80

	/* #322 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554859
	/* java_name */
	.ascii	"java/net/URLConnection"
	.zero	70

	/* #323 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554856
	/* java_name */
	.ascii	"java/net/UnknownServiceException"
	.zero	60

	/* #324 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554886
	/* java_name */
	.ascii	"java/nio/Buffer"
	.zero	77

	/* #325 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554888
	/* java_name */
	.ascii	"java/nio/ByteBuffer"
	.zero	73

	/* #326 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554893
	/* java_name */
	.ascii	"java/nio/channels/ByteChannel"
	.zero	63

	/* #327 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554895
	/* java_name */
	.ascii	"java/nio/channels/Channel"
	.zero	67

	/* #328 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554890
	/* java_name */
	.ascii	"java/nio/channels/FileChannel"
	.zero	63

	/* #329 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554897
	/* java_name */
	.ascii	"java/nio/channels/GatheringByteChannel"
	.zero	54

	/* #330 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554899
	/* java_name */
	.ascii	"java/nio/channels/InterruptibleChannel"
	.zero	54

	/* #331 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554901
	/* java_name */
	.ascii	"java/nio/channels/ReadableByteChannel"
	.zero	55

	/* #332 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554903
	/* java_name */
	.ascii	"java/nio/channels/ScatteringByteChannel"
	.zero	53

	/* #333 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554905
	/* java_name */
	.ascii	"java/nio/channels/SeekableByteChannel"
	.zero	55

	/* #334 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554907
	/* java_name */
	.ascii	"java/nio/channels/WritableByteChannel"
	.zero	55

	/* #335 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554908
	/* java_name */
	.ascii	"java/nio/channels/spi/AbstractInterruptibleChannel"
	.zero	42

	/* #336 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554873
	/* java_name */
	.ascii	"java/security/KeyStore"
	.zero	70

	/* #337 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554875
	/* java_name */
	.ascii	"java/security/KeyStore$LoadStoreParameter"
	.zero	51

	/* #338 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554877
	/* java_name */
	.ascii	"java/security/KeyStore$ProtectionParameter"
	.zero	50

	/* #339 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554872
	/* java_name */
	.ascii	"java/security/Principal"
	.zero	69

	/* #340 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554878
	/* java_name */
	.ascii	"java/security/SecureRandom"
	.zero	66

	/* #341 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554879
	/* java_name */
	.ascii	"java/security/cert/Certificate"
	.zero	62

	/* #342 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554881
	/* java_name */
	.ascii	"java/security/cert/CertificateFactory"
	.zero	55

	/* #343 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554884
	/* java_name */
	.ascii	"java/security/cert/X509Certificate"
	.zero	58

	/* #344 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554883
	/* java_name */
	.ascii	"java/security/cert/X509Extension"
	.zero	60

	/* #345 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554810
	/* java_name */
	.ascii	"java/util/ArrayList"
	.zero	73

	/* #346 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554799
	/* java_name */
	.ascii	"java/util/Collection"
	.zero	72

	/* #347 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554862
	/* java_name */
	.ascii	"java/util/Enumeration"
	.zero	71

	/* #348 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554801
	/* java_name */
	.ascii	"java/util/HashMap"
	.zero	75

	/* #349 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554819
	/* java_name */
	.ascii	"java/util/HashSet"
	.zero	75

	/* #350 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554864
	/* java_name */
	.ascii	"java/util/Iterator"
	.zero	74

	/* #351 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554865
	/* java_name */
	.ascii	"java/util/Random"
	.zero	76

	/* #352 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554867
	/* java_name */
	.ascii	"java/util/concurrent/Executor"
	.zero	63

	/* #353 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554869
	/* java_name */
	.ascii	"java/util/concurrent/Future"
	.zero	65

	/* #354 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554870
	/* java_name */
	.ascii	"java/util/concurrent/TimeUnit"
	.zero	63

	/* #355 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554551
	/* java_name */
	.ascii	"javax/net/SocketFactory"
	.zero	69

	/* #356 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554556
	/* java_name */
	.ascii	"javax/net/ssl/HostnameVerifier"
	.zero	62

	/* #357 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554553
	/* java_name */
	.ascii	"javax/net/ssl/HttpsURLConnection"
	.zero	60

	/* #358 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554558
	/* java_name */
	.ascii	"javax/net/ssl/KeyManager"
	.zero	68

	/* #359 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554567
	/* java_name */
	.ascii	"javax/net/ssl/KeyManagerFactory"
	.zero	61

	/* #360 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554568
	/* java_name */
	.ascii	"javax/net/ssl/SSLContext"
	.zero	68

	/* #361 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554560
	/* java_name */
	.ascii	"javax/net/ssl/SSLSession"
	.zero	68

	/* #362 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554562
	/* java_name */
	.ascii	"javax/net/ssl/SSLSessionContext"
	.zero	61

	/* #363 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554569
	/* java_name */
	.ascii	"javax/net/ssl/SSLSocketFactory"
	.zero	62

	/* #364 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554564
	/* java_name */
	.ascii	"javax/net/ssl/TrustManager"
	.zero	66

	/* #365 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554571
	/* java_name */
	.ascii	"javax/net/ssl/TrustManagerFactory"
	.zero	59

	/* #366 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554566
	/* java_name */
	.ascii	"javax/net/ssl/X509TrustManager"
	.zero	62

	/* #367 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554547
	/* java_name */
	.ascii	"javax/security/cert/Certificate"
	.zero	61

	/* #368 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554549
	/* java_name */
	.ascii	"javax/security/cert/X509Certificate"
	.zero	57

	/* #369 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33555010
	/* java_name */
	.ascii	"mono/android/TypeManager"
	.zero	68

	/* #370 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554795
	/* java_name */
	.ascii	"mono/android/runtime/InputStreamAdapter"
	.zero	53

	/* #371 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	0
	/* java_name */
	.ascii	"mono/android/runtime/JavaArray"
	.zero	62

	/* #372 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554816
	/* java_name */
	.ascii	"mono/android/runtime/JavaObject"
	.zero	61

	/* #373 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554834
	/* java_name */
	.ascii	"mono/android/runtime/OutputStreamAdapter"
	.zero	52

	/* #374 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554592
	/* java_name */
	.ascii	"mono/android/view/View_OnClickListenerImplementor"
	.zero	43

	/* #375 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554480
	/* java_name */
	.ascii	"mono/androidx/appcompat/app/ActionBar_OnMenuVisibilityListenerImplementor"
	.zero	19

	/* #376 */
	/* module_index */
	.word	4
	/* type_token_id */
	.word	33554506
	/* java_name */
	.ascii	"mono/androidx/appcompat/widget/Toolbar_OnMenuItemClickListenerImplementor"
	.zero	19

	/* #377 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554481
	/* java_name */
	.ascii	"mono/androidx/core/view/ActionProvider_SubUiVisibilityListenerImplementor"
	.zero	19

	/* #378 */
	/* module_index */
	.word	5
	/* type_token_id */
	.word	33554485
	/* java_name */
	.ascii	"mono/androidx/core/view/ActionProvider_VisibilityListenerImplementor"
	.zero	24

	/* #379 */
	/* module_index */
	.word	3
	/* type_token_id */
	.word	33554462
	/* java_name */
	.ascii	"mono/androidx/drawerlayout/widget/DrawerLayout_DrawerListenerImplementor"
	.zero	20

	/* #380 */
	/* module_index */
	.word	9
	/* type_token_id */
	.word	33554479
	/* java_name */
	.ascii	"mono/androidx/fragment/app/FragmentManager_OnBackStackChangedListenerImplementor"
	.zero	12

	/* #381 */
	/* module_index */
	.word	16
	/* type_token_id */
	.word	33554456
	/* java_name */
	.ascii	"mono/com/google/android/material/behavior/SwipeDismissBehavior_OnDismissListenerImplementor"
	.zero	1

	/* #382 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554927
	/* java_name */
	.ascii	"mono/java/lang/RunnableImplementor"
	.zero	58

	/* #383 */
	/* module_index */
	.word	6
	/* type_token_id */
	.word	33554543
	/* java_name */
	.ascii	"xamarin/android/net/OldAndroidSSLSocketFactory"
	.zero	46

	.size	map_java, 38400
/* Java to managed map: END */

