// COMPILE ERROR
// issue OD#846

#define TEST(x) x

/proc/RunTest()
	var/TEST = new /obj()
	var/t = TEST .type
	ASSERT(t == /obj)
