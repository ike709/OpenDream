#define SOMEDEF1 0
#define SOMEDEF2 0
#define SOMEDEF3 1

#if SOMEDEF1

#if SOMEDEF2

var/a = 1

#elif SOMEDEF3

var/a = 2

#else

var/a = 3

#endif

#else

var/a = 4

#endif

/proc/RunTest()
    ASSERT(a == 4)