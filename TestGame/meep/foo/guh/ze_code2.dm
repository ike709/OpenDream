

//world/var/static/code2 = world.do_assert(4)

/datum/foo
    var/static/meep = do_assert(0)

/datum/foo/New()
	world.log << "i like trains"
	return ..()