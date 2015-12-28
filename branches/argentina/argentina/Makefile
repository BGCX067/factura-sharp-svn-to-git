CC=gmcs
LDFLAGS=-target:library -r:System.Xml.Linq -r:System.Web.Services -r:$(project_libs_dir)/FacturaSharp.Core.Pkcs7.dll
CFLAGS=-debug:+

sources=$(shell cat sources.txt)
output=$(output_prefix)/Argentina.dll

all: $(output)

clean: _clean_output

$(output): $(sources)
	$(CC) $(LDFLAGS) $(CFLAGS) -out:$(output) @sources.txt

_clean_output:
	rm $(output) $(output).* || test 0
