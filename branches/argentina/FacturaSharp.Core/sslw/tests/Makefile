include ../definitions.mk

src_dir=src
#linux_output_dir=../$(output_dir)/linux
linux_output_dir = $(output_prefix)
headers_dir = ../build/include
tests_output_dir = build
target = $(src_dir)/pkcs7_sign.c
output = $(tests_output_dir)/pkcs7_sign

LDFLAGS=-L$(linux_output_dir) -lsslw


all: $(output)

$(output): $(target)
	$(CC) $(target) -o $(output) -I$(headers_dir) $(LDFLAGS)
	cp $(linux_output_dir)/libsslw.so $(tests_output_dir) 2> /dev/null || test 0

clean:
	rm $(output) 2> /dev/null || test 0

