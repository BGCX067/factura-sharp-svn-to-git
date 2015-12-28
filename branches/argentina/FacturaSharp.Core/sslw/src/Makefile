include ../definitions.mk

GC=gcc
LD=ld
LDFLAGS=-lssl -shared
temp_dir=./tmp
#build_dir=../$(output_dir)
linux_build_dir=$(output_prefix)
common_build_dir=../build/include
target = sslw.c
temp_output=$(temp_dir)/sslw.o
output=$(linux_build_dir)/libsslw.so
header=sslw.h

all: _mktemp $(output)

_mktemp:
	mkdir tmp  2> /dev/null || test 0

_rmtemp:
	rm -rf tmp 2> /dev/null || test 0

$(output): $(target)
	$(GC) -c $(target) -o $(temp_output)
	$(LD) -o $@ $(temp_output) $(LDFLAGS)
	cp $(header) $(common_build_dir)

clean: _rmtemp
	rm $(temp_output) $(output) $(common_build_dir)/$(header) 2> /dev/null || test 0

