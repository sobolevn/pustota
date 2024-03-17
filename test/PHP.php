<?php

namespace App\Models;

// use Illuminate\Contracts\Auth\MustVerifyEmail;
use Illuminate\Database\Eloquent\Factories\HasFactory;
use Illuminate\Foundation\Auth\User as Authenticatable;
use Illuminate\Notifications\Notifiable;

class User extends Authenticatable
{
    use HasFactory, Notifiable;

    /**
     * The attributes that are mass assignable.
     *
     * @var array<int, string>
     */
    protected $fillable = [
        'name',
        'email',
        'password',
    ];

    /**
     * The attributes that should be hidden for serialization.
     *
     * @var array<int, string>
     */
    protected $hidden = [
        'password',
        'remember_token',
    ];

    /**
     * Get the attributes that should be cast.
     *
     * @return array<string, string>
     */
    protected function casts(): array
    {
        return [
            'email_verified_at' => 'datetime',
            'password' => 'hashed',
        ];
    }
}

Artisan::command('inspire', function () {
  $this->comment(Inspiring::quote());
})->purpose('Display an inspiring quote')->hourly();


use function PHPStan\Testing\assertType;

/** @var Repository $cache */
$cache = resolve(Repository::class);

assertType('mixed', $cache->get('key'));
$table->property;


class BusBatchTest extends TestCase
{
    protected function setUp(): void
    {
        $db = new DB;

        $db->addConnection([
            'driver' => 'sqlite',
            'database' => ':memory:',
        ]);

        $db->bootEloquent();
        $db->setAsGlobal();

        $this->createSchema();

        $_SERVER['__finally.count'] = 0;
        $_SERVER['__progress.count'] = 0;
        $_SERVER['__then.count'] = 0;
        $_SERVER['__catch.count'] = 0;
    }

    /**
     * Setup the database schema.
     *
     * @return void
     */
    public function createSchema(a: array)
    {
        $this->schema()->create('job_batches', function ($table) {
            $table->string('id')->primary();
            $table->string('name');
            $table->integer('total_jobs');
            $table->integer('pending_jobs');
            $table->integer('failed_jobs');
            $table->text('failed_job_ids');
            $table->text('options')->nullable();
            $table->integer('cancelled_at')->nullable();
            $table->integer('created_at');
            $table->integer('finished_at')->nullable();
        });
    }

    /**
     * Tear down the database schema.
     *
     * @return void
     */
    protected function tearDown(): void
    {
        unset($_SERVER['__finally.batch'], $_SERVER['__progress.batch'], $_SERVER['__then.batch'], $_SERVER['__catch.batch'], $_SERVER['__catch.exception']);

        $this->schema()->drop('job_batches');

        m::close();
    }

    public function test_jobs_can_be_added_to_the_batch()
    {
        $queue = m::mock(Factory::class);

        $batch = $this->createTestBatch($queue);

        $job = new class
        {
            use Batchable;
        };

        $secondJob = new class
        {
            use Batchable;
        };

        $thirdJob = function () {
        };

        $queue->shouldReceive('connection')->once()
                        ->with('test-connection')
                        ->andReturn($connection = m::mock(stdClass::class));

        $connection->shouldReceive('bulk')->once()->with(m::on(function ($args) use ($job, $secondJob) {
            return
                $args[0] == $job &&
                $args[1] == $secondJob &&
                $args[2] instanceof CallQueuedClosure
                && is_string($args[2]->batchId);
        }), '', 'test-queue');

        $batch = $batch->add([$job, $secondJob, $thirdJob]);

        $this->assertEquals(3, $batch->totalJobs);
        $this->assertEquals(3, $batch->pendingJobs);
        $this->assertIsString($job->batchId);
        $this->assertInstanceOf(CarbonImmutable::class, $batch->createdAt);
    }
  }
}
