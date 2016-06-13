module.exports = function (grunt) {
    // load Grunt plugins from NPM
    grunt.loadNpmTasks('grunt-contrib-uglify');
    grunt.loadNpmTasks('grunt-contrib-watch');
    grunt.loadNpmTasks('grunt-contrib-less');

    // configure plugins
    grunt.initConfig({

        uglify: {
            my_target: {
                files: { '../FpWeb/app.js': ['App/app.js', 'App/**/*.js'] }
            }
        },

        less: {
            dist: {
                files: {
                    '../FpWeb/style.css': 'Content/style.less'
                }
            }
        },

        watch: {
            scripts: {
                files: ['App/**/*.js'],
                tasks: ['uglify']
            },
            css: {
                files: ['Content/**/*.less'],
                tasks: ['less']
            }
        }
    });

    // define tasks
    grunt.registerTask('default', ['uglify', 'less', 'watch']);
};